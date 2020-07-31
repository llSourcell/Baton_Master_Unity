#if UNITY_ANDROID
using System.Reflection;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UnityEditor.XR.Oculus
{
    internal class OculusVulkanWarning : IPreprocessBuildWithReport
    {
        public int callbackOrder { get { return 10000; } }

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.Android))
            {
                GraphicsDeviceType[] apis = PlayerSettings.GetGraphicsAPIs(BuildTarget.Android);
                if (apis.Length >= 1 && apis[0] == GraphicsDeviceType.Vulkan)
                {
                    throw new BuildFailedException("XR is currently not supported when using the Vulkan Graphics API. Please go to PlayerSettings and remove 'Vulkan' from the list of Graphics APIs.");
                }
            }
        }
    }


    internal class OculusManifest : IPostGenerateGradleAndroidProject
    {
        static readonly string k_AndroidURI = "http://schemas.android.com/apk/res/android";

        static readonly string k_AndroidManifestPath = "/src/main/AndroidManifest.xml";

        void UpdateOrCreateAttributeInTag(XmlDocument doc, string parentPath, string tag, string name, string value)
        {
            var xmlNode = doc.SelectSingleNode(parentPath + "/" + tag);

            if (xmlNode != null)
            {
                ((XmlElement)xmlNode).SetAttribute(name, k_AndroidURI, value);
            }
        }

        void UpdateOrCreateNameValueElementsInTag(XmlDocument doc, string parentPath, string tag,
            string firstName, string firstValue, string secondName, string secondValue)
        {
            var xmlNodeList = doc.SelectNodes(parentPath + "/" + tag);

            foreach (XmlNode node in xmlNodeList)
            {
                var attributeList = ((XmlElement)node).Attributes;

                foreach (XmlAttribute attrib in attributeList)
                {
                    if (attrib.Value == firstValue)
                    {
                        XmlAttribute valueAttrib = attributeList[secondName, k_AndroidURI];
                        if (valueAttrib != null)
                        {
                            valueAttrib.Value = secondValue;
                        }
                        else
                        {
                            ((XmlElement)node).SetAttribute(secondName, k_AndroidURI, secondValue);
                        }
                        return;
                    }
                }
            }
            
            // Didn't find any attributes that matched, create both (or all three)
            XmlElement childElement = doc.CreateElement(tag);
            childElement.SetAttribute(firstName, k_AndroidURI, firstValue);
            childElement.SetAttribute(secondName, k_AndroidURI, secondValue);

            var xmlParentNode = doc.SelectSingleNode(parentPath);

            if (xmlParentNode != null)
            {
                xmlParentNode.AppendChild(childElement);
            }
        }

        // same as above, but don't create if the node already exists.
        void CreateNameValueElementsInTag(XmlDocument doc, string parentPath, string tag,
            string firstName, string firstValue, string secondName, string secondValue, string thirdName=null, string thirdValue=null)
        {
            var xmlNodeList = doc.SelectNodes(parentPath + "/" + tag);

            // don't create if the firstValue matches
            foreach (XmlNode node in xmlNodeList)
            {
                foreach (XmlAttribute attrib in node.Attributes)
                {
                    if (attrib.Value == firstValue)
                    {
                        return;
                    }
                }
            }
            
            XmlElement childElement = doc.CreateElement(tag);
            childElement.SetAttribute(firstName, k_AndroidURI, firstValue);
            childElement.SetAttribute(secondName, k_AndroidURI, secondValue);

            if (thirdValue != null)
            {
                childElement.SetAttribute(thirdName, k_AndroidURI, thirdValue);
            }

            var xmlParentNode = doc.SelectSingleNode(parentPath);

            if (xmlParentNode != null)
            {
                xmlParentNode.AppendChild(childElement);
            }
        }

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            var manifestPath = path + k_AndroidManifestPath;
            var manifestDoc = new XmlDocument();
            manifestDoc.Load(manifestPath);

            var minSdkVersion = (int)PlayerSettings.Android.minSdkVersion;

            UpdateOrCreateAttributeInTag(manifestDoc, "/", "manifest", "installLocation", "auto");

            var nodePath = "/manifest/application";
            UpdateOrCreateNameValueElementsInTag(manifestDoc, nodePath, "meta-data", "name", "com.samsung.android.vr.application.mode", "value", "vr_only");

            nodePath = "/manifest/application";
            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "screenOrientation", "landscape");
            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "theme", "@android:style/Theme.Black.NoTitleBar.Fullscreen");

            var configChangesValue = "keyboard|keyboardHidden|navigation|orientation|screenLayout|screenSize|uiMode";
            configChangesValue = ((minSdkVersion >= 24) ? configChangesValue + "|density" : configChangesValue);
            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "configChanges", configChangesValue);

            if (minSdkVersion >= 24)
            {
                UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "resizeableActivity", "false");
            }

            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "launchMode", "singleTask");

            // check to see if the v2Signing property exists
            var type = typeof(PlayerSettings.VROculus);
            var propInfo = type.GetProperty("v2Signing");

            if (propInfo != null)
            {
                bool v2Signing = (bool)propInfo.GetValue(null, null);

                if (v2Signing == true)
                {
                    nodePath = "/manifest";
                    CreateNameValueElementsInTag(manifestDoc, nodePath, "uses-feature", "name", "android.hardware.vr.headtracking", "required", "true", "version", "1");
                }
            }

	        // Uncomment the following block to add additional manifest entries required for store release submissions
            
            //nodePath = "/manifest/application";
            //UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "excludeFromRecents", "true");

            //nodePath = "/manifest/application/activity/intent-filter";
            //UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "action", "name", "android.intent.action.MAIN");
            //UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "category", "name", "android.intent.category.INFO");

            //nodePath = "/manifest/application";
            //UpdateOrCreateNameValueElementsInTag(manifestDoc, nodePath, "meta-data", "name", "unityplayer.SkipPermissionsDialog", "value", "false");
            
            manifestDoc.Save(manifestPath);
        }

        public int callbackOrder { get { return 2; } }

        void DebugPrint(XmlDocument doc)
        {
            var sw = new System.IO.StringWriter();
            var xw = XmlWriter.Create(sw);
            doc.Save(xw);
            Debug.Log(sw);
        }
    }
}
#endif
