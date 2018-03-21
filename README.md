# FormsBuildTime

A quick sample to show how setting `DebugType=portable` can improve Xamarin.Android build times on Windows.

Here is what I did to reproduce this:
- Checked out a copy of `xamarin-android/master/1826ec2` and built it on Windows `msbuild Xamarin.Android.sln /t:Prepare` then `msbuild Xamarin.Android.sln`
- Checked out this repo

Did the following steps w/ a default template:
```
git clean -dxf
msbuild FormsBuildTime.sln /t:Restore
../xamarin-android/bin/Debug/bin/xabuild.exe FormsBuildTime.sln /bl:DebugType_full.binlog
```

Then changed `DebugType=portable`, and repeated:
```
git clean -dxf
msbuild FormsBuildTime.sln /t:Restore
../xamarin-android/bin/Debug/bin/xabuild.exe FormsBuildTime.sln /bl:DebugType_portable.binlog
```

I committed my two `binlog` files in this repo for review.

## Improvements

The `_ConvertPdbFiles` target gets skipped (as it should) when `DebugType=portable`. From this log it was taking ~3.8 seconds.

Overall the build when from 30.985s to 25.697s just by changing `DebugType` to `portable`. This is about a 5.2 second improvement for a default project.

# What should we change?

1. VS 2017 for Windows could make templates default to `DebugType=portable`. There was once some concerns about VS 2015, but we support it no longer, right?

1. VS for Mac should also change their templates to match VS 2017, to support better build times on Windows. A user could create the project on Mac, and another user work on the same project on Windows. Build times will not be improved on Mac, however.