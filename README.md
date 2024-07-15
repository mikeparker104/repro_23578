# Repro for .NET MAUI issue #23578

**Ref:** [#23578 - Behavior bindable property with DynamicResource not supported](https://github.com/dotnet/maui/issues/23578)

## Repro steps

### Scenario 1

1. Run application
1. Observe application output for ```MyColorPropertyChanged``` messages

#### Scenario 1 - Expected behavior

There should be 2 ```MyColorPropertyChanged``` trace messages output on startup indicating that the ```ReproBehavior``` ```MyColor``` property value has been set to red ```[Color: Red=1, Green=0, Blue=0, Alpha=1]```.

#### Scenario 1 - Actual behavior

Only 1 ```MyColorPropertyChanged``` trace message is output on startup. In this case, for the property being set with ```StaticResource```. A property value is not set for the behavior using ```DynamicResource```.

### Scenario 2

1. Run application
1. Ignore application outputs for ```MyColorPropertyChanged``` messages from start-up
1. Click the ```Switch Theme``` Button
1. Observe application output for ```MyColorPropertyChanged``` messages

#### Scenario 2 - Expected behavior

There should be a ```MyColorPropertyChanged``` trace message output after clicking the ```Switch Theme``` Button. In this case, indicating that the ```ReproBehavior``` ```MyColor``` property, set with ```DynamicResource```, has been updated following changes to resources.

#### Scenario 2 - Actual behavior

No ```MyColorPropertyChanged``` trace message gets output after clicking the ```Switch Theme``` Button.

> [!NOTE]
> The expected value is being set on startup, and updated based on subsequent changes to resources, when the same ```DynamicResource``` is used on the parent ```Image``` ```BackgroundColor``` property.
