using NumericTypesSuggester.App;
using NumericTypesSuggester.Constants;
using System.Numerics;

namespace NumericTypesSuggester;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
        ToggleMustBePreciseControl();
    }

    private void MinValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = ValidateNumericInput(e.KeyChar, (TextBox)sender);
    }

    private void MaxValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = ValidateNumericInput(e.KeyChar, (TextBox)sender);
    }

    private void MinValueTextBox_TextChanged(object sender, EventArgs e)
    {
        ValidateNumericalValuesLogic();
    }

    private void MaxValueTextBox_TextChanged(object sender, EventArgs e)
    {
        ValidateNumericalValuesLogic();
    }

    private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        ToggleMustBePreciseControl();
    }

    private void ValidateNumericalValuesLogic()
    {

        if (!string.IsNullOrWhiteSpace(MinValueTextBox.Text)
            && !string.IsNullOrWhiteSpace(MaxValueTextBox.Text)
            && MinValueTextBox.Text != "-"
            && MaxValueTextBox.Text != "-")
        {
                BigInteger minValue = BigInteger.Parse(MinValueTextBox.Text ?? "0");
                BigInteger maxValue = BigInteger.Parse(MaxValueTextBox.Text ?? "0");
                DisplayResult(minValue, maxValue);
        }
    }

    private void DisplayResult<T>(T minValue, T maxValue) where T : INumber<T>
    {
        if (minValue > maxValue)
        {
            MaxValueTextBox.BackColor = Color.DarkRed;
        }
        else
        {
            MaxValueTextBox.ResetBackColor();
        }
        try
        {
            DataDisplayLabel.Text = typeof(T).Name;
        }
        catch (ArgumentException e)
        {
            DataDisplayLabel.Text = Labels.NotEnoughData;
        }
    }
    
    private bool ValidateNumericInput(char enteredChar, TextBox textBox)
    {

        if (char.IsDigit(enteredChar) || char.IsControl(enteredChar))
        {
            return false;
        }
        else
        {
            if (textBox.SelectionStart == 0)
            {
                if (enteredChar == '-' && textBox.Text.Count(character=>character == '-') < 1)
                {
                    return false;
                }
            }
            return true;
        }
    }

    private void ToggleMustBePreciseControl()
    {
        MustBePreciseLabel.Visible = !IntegralOnlyCheckBox.Checked;
        MustBePreciseCheckBox.Visible = !IntegralOnlyCheckBox.Checked;
    }
}
