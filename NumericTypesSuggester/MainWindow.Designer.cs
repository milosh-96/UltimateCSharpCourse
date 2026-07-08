namespace NumericTypesSuggester;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        MinValueTextBox = new TextBox();
        MaxValueTextBox = new TextBox();
        IntegralOnlyCheckBox = new CheckBox();
        label4 = new Label();
        DataDisplayLabel = new Label();
        MustBePreciseLabel = new Label();
        MustBePreciseCheckBox = new CheckBox();
        SuspendLayout();
        // 
        // label1
        // 
        resources.ApplyResources(label1, "label1");
        label1.Name = "label1";
        // 
        // label2
        // 
        resources.ApplyResources(label2, "label2");
        label2.Name = "label2";
        // 
        // label3
        // 
        resources.ApplyResources(label3, "label3");
        label3.Name = "label3";
        // 
        // MinValueTextBox
        // 
        resources.ApplyResources(MinValueTextBox, "MinValueTextBox");
        MinValueTextBox.Name = "MinValueTextBox";
        MinValueTextBox.TextChanged += MinValueTextBox_TextChanged;
        MinValueTextBox.KeyPress += MinValueTextBox_KeyPress;
        // 
        // MaxValueTextBox
        // 
        resources.ApplyResources(MaxValueTextBox, "MaxValueTextBox");
        MaxValueTextBox.Name = "MaxValueTextBox";
        MaxValueTextBox.TextChanged += MaxValueTextBox_TextChanged;
        MaxValueTextBox.KeyPress += MaxValueTextBox_KeyPress;
        // 
        // IntegralOnlyCheckBox
        // 
        resources.ApplyResources(IntegralOnlyCheckBox, "IntegralOnlyCheckBox");
        IntegralOnlyCheckBox.Checked = true;
        IntegralOnlyCheckBox.CheckState = CheckState.Checked;
        IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
        IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
        IntegralOnlyCheckBox.CheckedChanged += IntegralOnlyCheckBox_CheckedChanged;
        // 
        // label4
        // 
        resources.ApplyResources(label4, "label4");
        label4.Name = "label4";
        // 
        // DataDisplayLabel
        // 
        resources.ApplyResources(DataDisplayLabel, "DataDisplayLabel");
        DataDisplayLabel.Name = "DataDisplayLabel";
        // 
        // MustBePreciseLabel
        // 
        resources.ApplyResources(MustBePreciseLabel, "MustBePreciseLabel");
        MustBePreciseLabel.Name = "MustBePreciseLabel";
        // 
        // MustBePreciseCheckBox
        // 
        resources.ApplyResources(MustBePreciseCheckBox, "MustBePreciseCheckBox");
        MustBePreciseCheckBox.Name = "MustBePreciseCheckBox";
        MustBePreciseCheckBox.UseVisualStyleBackColor = true;
        // 
        // MainWindow
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(MustBePreciseCheckBox);
        Controls.Add(MustBePreciseLabel);
        Controls.Add(DataDisplayLabel);
        Controls.Add(label4);
        Controls.Add(IntegralOnlyCheckBox);
        Controls.Add(MaxValueTextBox);
        Controls.Add(MinValueTextBox);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "MainWindow";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox MinValueTextBox;
    private TextBox MaxValueTextBox;
    private CheckBox IntegralOnlyCheckBox;
    private Label label4;
    private Label DataDisplayLabel;
    private Label MustBePreciseLabel;
    private CheckBox MustBePreciseCheckBox;
}
