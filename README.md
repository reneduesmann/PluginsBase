## RD.PluginsBase - Base Class for Plugins in Dynamics 365 CRM

### Overview

RD.PluginsBase provide a base class for dynamics 365 plugins to write better and more clearly structured code.
You get easy access of the input and output parameters of the provided messages without having to do anything manually.

### License
RD.PluginsBase is licensed under the [MIT](https://github.com/reneduesmann/PluginsBase/blob/master/LICENSE) license.

### Installation
Install the NuGet package from the NuGet Package Manager or from the package manager console:
```powershell
Install-Package RD.PluginsBase
```

### Important to Know
> [!IMPORTANT]
> When installing this nuget package, the files will be copied in the project in a `libs` directory to prevent using ILMerge.

## Table of Contents
* [Prerequisite](#prerequisite)
* [Why](#why)
* [Future](#future)
* [Messages and Contexts](#messages-and-contexts)
* [Examples](#examples)
  * [General Informations](#general-informations)
  * [Different step registrations](#different-step-registrations)
    * [Native values](#native-values)
    * [With enums](#with-enums)
  * [Create](#create)
  * [Create/Update/Delete the same method](#createupdatedelete-the-same-method)
  * [Earlybounds](#earlybounds)
* [Custom Steps and Contexts](#custom-steps-and-contexts)

### Prerequisite
- .NET Framework 4.7.1
  - Latest version that Dynamics 365 CRM supports
- Project must support Implicit Usings or using Global Usings
  - Library use less usings
- C# Language Version must be set at least to 10
  - Library use file-scoped namespaces and more features

### Why?
- Supports Earlybounds
  - Target, PreImage, PostImage automatically parsed
- Less boilerplate code
  - Dont need to get the Interfaces from the IServiceProvider
  - Directly access to input and output parameters without accessing the IPluginExecutionContext
- Structured code
  - Good overview of registered steps
- Target methods will only be executed when the message, stage and entity fits
  - Your method that handle your logic, will only be called, how you register it
- Simple access to the provided Interfaces from the SDK e. g. IOrganizationService
  - Contexts provide properties to all necessary interfaces
- Contexts and Messages are expandable
  - Extend the library with two classes and write less boilerplate code
- Simple access to the input and output parameters for defined messages
  - Contexts provide properties for the values that are in the input and output parameters
- Natively supported messages:
  - Create
  - Update
  - Delete
  - Associate
  - Disassociate
  - Merge
  - CalculatePrice
  - Lose
  - Win
  - QualifyLead
  - Retrieve
  - RetrieveMultiple

### Future
- [ ] More messages
- [ ] Provide simple calls to custom apis and actions
- [ ] Localization with resource files
- [ ] Do you have a wish? Create an issue.

### Messages and Contexts
Every supported message have their own context that can be accessed and provide additional informations from the message.
As example, when using the `QualifyLeadStep`, you get the `QualifyLeadContext`.
In this context you have access to the values for create account/contact/opportunity.
Every context inherits the `PluginContext` and that is the main context for every context and provide 
as example the interfaces like `IOrganizationService`.
And every step(message) inherits the `PluginStep`.

### Examples

#### General Informations

Plugins that wants to use this library, must inherit the abstract class `PluginBase` and
override the `RegisteredSteps` property. You can directly add the steps to the property or in the constructor.
If you need a message that is currently not supported, you can use the general `PluginStep` to register the step.

#### Different step registrations

##### Native values

You can register steps with native values like the stage (10, 20, 40).

```csharp
public class GithubPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public GithubPlugin()
    {
        this.RegisteredSteps = new()
        {
            new CreateStep(40, "account", this.ExecuteAccountLogic),
            new CreateStep(40, "account", this.ExecuteSecondAccountLogic)
        };
    }

    private void ExecuteAccountLogic(PluginContext context)
    {
        IPluginExecutionContext pluginExecutionContext = context.PluginExecutionContext;
        IOrganizationService organizationService = context.OrganizationService;
    }

    private void ExecuteSecondAccountLogic(CreateContext context)
    {
        Entity target = context.Target;
        Entity preImage = context.PreImage;
        Entity postImage = context.PostImage;
    }
}
```

##### With enums

But you also can set the stage with the `PluginStage` enum.

```csharp
public class GithubPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public GithubPlugin()
    {
        this.RegisteredSteps = new()
        {
            new CreateStep(PluginStage.PostOperation, "account", this.ExecuteAccountLogic),
            new CreateStep(PluginStage.PreOperation, "account", this.ExecuteSecondAccountLogic)
        };
    }

    private void ExecuteAccountLogic(PluginContext context)
    {
        IPluginExecutionContext pluginExecutionContext = context.PluginExecutionContext;
        IOrganizationService organizationService = context.OrganizationService;
    }

    private void ExecuteSecondAccountLogic(CreateContext context)
    {
        Entity target = context.Target;
        Entity preImage = context.PreImage;
        Entity postImage = context.PostImage;
    }
\
```

#### Create

Use the existing `CreateStep` or the general `PluginStep` to register
a step.
When using the `PluginStep`, you must provide the message for the registration.
For the `CreateStep` not.

```csharp
public class GithubPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public GithubPlugin()
    {
        this.RegisteredSteps = new()
        {
            new CreateStep(40, "account", this.ExecuteAccountLogic),
            new PluginStep(20, "create", "account", this.ExecuteAccountLogic)
        };
    }

    private void ExecuteAccountLogic(PluginContext context)
    {
        IPluginExecutionContext pluginExecutionContext = context.PluginExecutionContext;
        IOrganizationService organizationService = context.OrganizationService;
    }
}
```

#### Create/Update/Delete the same method

When you need to execute the same logic on create, update and/or delete, you can target
a single method with a base context for these three steps.
Every single step have also their own contexts (`CreateContext`, `UpdateContext`, `DeleteContext`).

```csharp
public class GithubPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public GithubPlugin()
    {
        this.RegisteredSteps = new()
        {
            new CreateStep(40, "account", this.ExecuteLogic),
            new UpdateStep(PluginStage.PreOperation, "account", this.ExecuteLogic),
            new DeleteStep(10, "account", this.ExecuteLogic)
        };
    }

    private void ExecuteLogic(CrudContext context)
    {
        Entity target = context.Target;
    }
}
```

#### Earlybounds

Every messages where you can define an entity, the steps also supports earlybounds.
In this case, you have directly a target that is an account and can access directly the properties without convert the Entity to it.
Also you dont need to configure the entity name for the step registration.

```csharp
public class GithubPlugin : PluginBase
{
    public override PluginStepCollection RegisteredSteps { get; }

    public GithubPlugin()
    {
        this.RegisteredSteps = new()
        {
            new UpdateStep<Account>(PluginStage.PreOperation, this.ExecuteLogic),
        };
    }

    private void ExecuteLogic(CrudContext<Account> context)
    {
        Account target = context.Target;
    }
}
```

### Custom Steps and Contexts

Let`s assume that you want to create a custom Query step for your project.
You can use the existing `PluginContext` context or create one that inherits this context.
```csharp
public class QueryContext : PluginContext 
{
    public string SomeValue
    {
        get
        {
            return "";//As example a value from the InputParameters (Accessible in the base class)
        }
    }

    public QueryContext(PluginContext context) : base(context)
    {

    }
}
```

After that, you create a step class for your message.
Your step must inherit from the `PluginStep` class.
The class provides three different methods to implement.
- Non-Generic
- Generic with Earlybound
- Generic with Earlybound and OrganizationRequest

The Non-Generic method need the stage, message, entity name and action as parameter.
The Generic with Earlybound method dont need the entity name as parameter.
The Generic with Earlybound and OrganizationRequest only need the stage and action as parameter.

```csharp
public class QueryStep : PluginStep
{
    public QueryStep(int stage, string message, string entityName, Action<PluginContext> action) 
        : this((PluginStage)stage, message, entityName, action)
    {
        
    }

    public QueryStep(PluginStage stage, string message, string entityName, Action<PluginContext> action)
        : base(stage, message, entityName, action)
    {
    }

    public QueryStep(int stage, string message, string entityName, Action<QueryContext> action)
        : this((PluginStage)stage, message, entityName, action)
    {

    }

    public QueryStep(PluginStage stage, string message, string entityName, Action<QueryContext> action)
        : base(stage, message, entityName, context => action(new QueryContext(context)))
    {

    }
}
```
