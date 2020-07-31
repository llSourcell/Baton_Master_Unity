# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [2.38.6] - 2019-12-17

Fixed an issue with manifest generation when combined with the 1.44 Oculus Integration assets.

## [2.38.5] - 2019-12-04

Fixed an issue introduced in 2.38.4 where some entries in a custom AndroidManifest.xml were getting removed when V2 signing was enabled.

## [2.38.4] - 2019-11-05

Added package deprecation information.
Bumped major version number to isolate deprecation messaging to packages targeting 2019.3+

## [1.38.6] - 2019-12-17

Fixed an issue with manifest generation when combined with the 1.44 Oculus Integration assets.

## [1.38.5] - 2019-12-04

Fixed an issue introduced in 1.38.4 where some entries in a custom AndroidManifest.xml were getting removed when V2 signing was enabled.

## [1.38.4] - 2019-11-01

Fixed an issue with colliding Android manifests breaking .apk generation.

## [1.38.3] - 2019-09-13

Bumped callbackOrder for the Vulkan preprocess warning to 10000 in case other assets modify the graphics settings.
Fixed a build script error when using .NET 3.5 scripting.

## [1.38.2] - 2019-08-06

Added support for the v2Signing PlayerSetting for Oculus Quest.

## [1.38.1] - 2019-07-25

Fail the Android player build if Vulkan is at the top oof the list of graphics APIs.

## [1.38.0] - 2019-07-02

Update Plugins to version 1.38.0

## [1.36.0] - 2019-05-09

Update Plugins to version 1.36.0

## [1.29.1] - 2018-10-29

Update the to the universal android plugin (arm64 and armv7 plugins included)

## [1.29.0] - 2018-10-01

Update Plugins to version 1.29.0

## [1.28.0] - 2018-08-17

Update Plugins to version 1.28.0

## [1.27.1] - 2018-08-01

Update Plugins to version 1.27.1

## [1.24.2] - 2018-06-13

Creates unique GUIDs for android and standalone packages so that they no longer conflict

## [1.24.1] - 2018-05-17

Update Unity compatible versions to 2018.3 and up

## [1.24.0] - 2018-04-20

Rename package to com.unity.xr.oculus.standalone/android

## [1.24.0] - 2018-04-19

Update Package jsons to the official package version for the first version.

## [0.0.4] - 2018-03-20

### Platform Package Separation

Updated Oculus to version 1.24.
Separated Oculus into platform specific packages and setup the repo to work with katana automation tools.

## [0.0.3] - 2018-03-01

### This is the first release of *Unity Package Oculus*.

This is the first test iteration of the Oculus XR Package using the Package Manager process.

The Current Oculus library version for this package is 1.21. Release notes for this version can be found here
(make sure to change the version in the drop on the page):
https://developer.oculus.com/downloads/package/unity-integration/
