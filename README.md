## MatBlazor - Material Design components for Blazor and Razor Components

MatBlazor comprises a range of components which implement common interaction patterns according to the Material Design specification.

If you like the idea of this repo leave your feedback as an issue or star the repo or let me know on.

## Demo and Documentation
https://blazorcomponents.github.io/MatBlazor/


## Prerequisites

Don't know what Blazor is? Read [here](https://github.com/aspnet/Blazor)

Complete all Blazor 0.9  dependencies.

- .NET Core 3.0 Preview 3 SDK (3.0.100-preview3-010431)
- Visual Studio 2019 (Preview 4 or later) with the ASP.NET and web development workload selected.
- The latest Blazor extension from the Visual Studio Marketplace.
- The Blazor templates on the command-line: dotnet new -i Microsoft.AspNetCore.Blazor.Templates::0.9.0-preview3-19154-02

## Installation 

![NuGet](https://img.shields.io/nuget/v/MatBlazor.svg)


To Install 

```
Install-Package MatBlazor
```
or 
```
dotnet add package MatBlazor
```

## MatBlazor components for Razor Components
At the beginning of the your application, usually in MainLayout.cshtml please add MatBlazorInstall component
```
<MatBlazorInstall />
```

## Components

- MatCheckbox
- MatTextField
- MatRadioButton
- MatSelect
- MatSlider
- MatSlideToggle

- MatDrawer
- MatAppBar
- MatMenu

- MatCard
- MatDivider
- MatList

- MatButton
- MatIconButton
- MatIcon
- MatChip


{% include_relative NEWS.md %}