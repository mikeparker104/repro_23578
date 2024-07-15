using Repro23578.Resources.Styles;

namespace Repro23578;

public partial class MainPage : ContentPage
{
    int _themeIndex = 0;

    readonly ResourceDictionary[] _themes = new ResourceDictionary[]
	{
		new ThemeA(),
		new ThemeB(),
		new ThemeC()
	};

    public MainPage()
	{
		InitializeComponent();
	}

	void OnSwitchThemeClicked(object sender, EventArgs e)
	{
        _themeIndex += 1;

        if (_themeIndex >= _themes.Length)
            _themeIndex = 0;

        App.Current.Resources = _themes[_themeIndex];

		SemanticScreenReader.Announce($"Theme {GetThemeNameFromIndex(_themeIndex)} set");
	}

	string GetThemeNameFromIndex(int index) => index switch
	{
        0 => nameof(ThemeA),
        1 => nameof(ThemeB),
		2 => nameof(ThemeC),
		_ => throw new Exception("Invalid theme index")
	};
}