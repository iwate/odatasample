# Differences between v7.x and v8.x

I've made simple OData endpoints and test codes to check endpoint for multiple-keys entity.
Then, I found v8.x doesn't support ways v7.x allows.

## Test data

https://github.com/iwate/odatasample/blob/9eda6b3ceb81e26524fb392a7fd3943799ca477d/ODataSample.Tests.V7/UnitTest1.cs#L16-L27

## Test Result

```
PS> dotnet test -v quiet
Test run for C:\Users\taniguchi\source\repos\ODataSample\ODataSample.Tests.V7\bin\Debug\net6.0\ODataSample.Tests.V7.dll (.NETCoreApp,Version=v6.0)
Test run for C:\Users\taniguchi\source\repos\ODataSample\ODataSample.Tests.V8\bin\Debug\net6.0\ODataSample.Tests.V8.dll (.NETCoreApp,Version=v6.0)
Microsoft (R) Test Execution Command Line Tool Version 17.6.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.
Microsoft (R) Test Execution Command Line Tool Version 17.6.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.


Starting test execution, please wait...
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:00.66]     ODataSample.Tests.V8.UnitTest1.GetWithMultipleKeys(request: "/Data(2, 'A')") [FAIL]
[xUnit.net 00:00:00.66]     ODataSample.Tests.V8.UnitTest1.GetWithMultipleKeys(request: "/Data(Key1=2, Key2='A')") [FAIL]
[xUnit.net 00:00:00.66]     ODataSample.Tests.V8.UnitTest1.GetWithMultipleKeys(request: "/Data(2,'A')") [FAIL]
[xUnit.net 00:00:00.77]     ODataSample.Tests.V8.UnitTest1.GetWithMultipleKeys(request: "/Data(Key2='A',Key1=2)") [FAIL]

Passed!  - Failed:     0, Passed:     5, Skipped:     0, Total:     5, Duration: 4 ms - ODataSample.Tests.V7.dll (net6.0)

Failed!  - Failed:     4, Passed:     1, Skipped:     0, Total:     5, Duration: 112 ms - ODataSample.Tests.V8.dll (net6.0)
```
