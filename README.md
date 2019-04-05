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


## News

### MatBlazor 0.6.10
- Added Elevation
- License of used packages added to js boundle

### MatBlazor 0.6.9
- Changed all events to EventCallback
- Show Icons when MatTextField has FullWidth (enkodellc)

### MatBlazor 0.6.8
- Improved events for MatTextField (sandrohanea + SamProf)

### MatBlazor 0.6.7
- Added Typography styles

### MatBlazor 0.6.6
- Added Href parameter to MatListItem component

### MatBlazor 0.6.5
- MatTextField - fixed label

### MatBlazor 0.6.4
- MatMenu - first working implementation

### MatBlazor 0.6.3
- New MatDrawer
- Fix MatAppBar (fixed-adjust div)

### MatBlazor 0.6.2
- Added Style Parameter for all components
- Added BaseMatComponent Docs
- MatDrawer in progress

### MatBlazor 0.6.1
- Introduce Razor Components support (MatBlazorInstall component)

### MatBlazor 0.6.0
- Upgrade Blazor 0.9 complete
- Upgrade to new Material Components
- MatTextField Outlined fixed
- MatRadioGroup and MatRadioButton enhancements
- MatSelect Outlined fixed
- MatSlider Step problem founded
- Fixed main page of the demo project MatDrawer
- MatMenu (prepared for development in next release)
- MatDrawer (prepared for development in next release)
- BlazorFiddle integration fixed

### MatBlazor 0.5.0
- Upgrade to Blazor 0.9.0 (Part 1)

### MatBlazor 0.4.5 (Minor)
- TrailingIcon in MatButton

### MatBlazor 0.4.4
- Added integration with BlazorFiddle.com
- MatIconButton - Href bacame Link

### MatBlazor 0.4.3
- Upgrade to Blazor 0.7.0
- MatDrawer in progress