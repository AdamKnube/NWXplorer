<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeekViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoobViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(65, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(313, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "No File Selected..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Log File:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Combat Logs|combat*.log|All Logs|*.log|All Files|*.*"
        Me.OpenFileDialog1.Title = "Locate Combat Logs"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(384, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Browse..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.AutoArrange = False
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(15, 93)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(602, 405)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ComboBox1
        '
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Player Damage (Total)", "NPC Damage (Total)", "Player Healing (Total)", "Player Damage (Target)", "NPC Damage (Target)", "Player Healing (Target)", "Custom..."})
        Me.ComboBox1.Location = New System.Drawing.Point(465, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 21)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.Text = "View Select..."
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"File Mode", "Live Mode"})
        Me.ComboBox2.Location = New System.Drawing.Point(15, 36)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(602, 21)
        Me.ComboBox2.TabIndex = 5
        Me.ComboBox2.Text = "Mode Select..."
        '
        'ComboBox3
        '
        Me.ComboBox3.Enabled = False
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(15, 66)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(136, 21)
        Me.ComboBox3.TabIndex = 6
        Me.ComboBox3.Text = "Attacker..."
        '
        'ComboBox4
        '
        Me.ComboBox4.Enabled = False
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(157, 66)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(146, 21)
        Me.ComboBox4.TabIndex = 7
        Me.ComboBox4.Text = "Action..."
        '
        'ComboBox5
        '
        Me.ComboBox5.Enabled = False
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(309, 66)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox5.TabIndex = 8
        Me.ComboBox5.Text = "Target..."
        '
        'ComboBox6
        '
        Me.ComboBox6.Enabled = False
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Items.AddRange(New Object() {"Itemized", "Totals"})
        Me.ComboBox6.Location = New System.Drawing.Point(465, 66)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(152, 21)
        Me.ComboBox6.TabIndex = 9
        Me.ComboBox6.Text = "Style..."
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(629, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeekViewToolStripMenuItem, Me.NoobViewToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ViewToolStripMenuItem.Text = "View..."
        '
        'GeekViewToolStripMenuItem
        '
        Me.GeekViewToolStripMenuItem.Name = "GeekViewToolStripMenuItem"
        Me.GeekViewToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.GeekViewToolStripMenuItem.Text = "Geek View"
        '
        'NoobViewToolStripMenuItem
        '
        Me.NoobViewToolStripMenuItem.Name = "NoobViewToolStripMenuItem"
        Me.NoobViewToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NoobViewToolStripMenuItem.Text = "Noob View"
        '
        'ComboBox7
        '
        Me.ComboBox7.Enabled = False
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Items.AddRange(New Object() {"Damage", "Healing"})
        Me.ComboBox7.Location = New System.Drawing.Point(465, 36)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(152, 21)
        Me.ComboBox7.TabIndex = 11
        Me.ComboBox7.Text = "View Select..."
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(15, 129)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(602, 369)
        Me.Chart1.TabIndex = 12
        Title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Title1.Name = "Title1"
        Title1.Text = "Damage"
        Title1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270
        Title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title2.Name = "Title2"
        Title2.Text = "Time in Seconds"
        Me.Chart1.Titles.Add(Title1)
        Me.Chart1.Titles.Add(Title2)
        '
        'ComboBox8
        '
        Me.ComboBox8.Enabled = False
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Items.AddRange(New Object() {"Show All Players", "Compare Players"})
        Me.ComboBox8.Location = New System.Drawing.Point(15, 66)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(136, 21)
        Me.ComboBox8.TabIndex = 13
        Me.ComboBox8.Text = "Chart Style..."
        '
        'ComboBox9
        '
        Me.ComboBox9.Enabled = False
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(157, 66)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(146, 21)
        Me.ComboBox9.TabIndex = 14
        Me.ComboBox9.Text = "Player 1"
        '
        'ComboBox10
        '
        Me.ComboBox10.Enabled = False
        Me.ComboBox10.FormattingEnabled = True
        Me.ComboBox10.Location = New System.Drawing.Point(309, 66)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox10.TabIndex = 15
        Me.ComboBox10.Text = "Player 2"
        '
        'ComboBox11
        '
        Me.ComboBox11.Enabled = False
        Me.ComboBox11.FormattingEnabled = True
        Me.ComboBox11.Location = New System.Drawing.Point(465, 66)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(152, 21)
        Me.ComboBox11.TabIndex = 16
        Me.ComboBox11.Text = "Player 3"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 510)
        Me.Controls.Add(Me.ComboBox11)
        Me.Controls.Add(Me.ComboBox10)
        Me.Controls.Add(Me.ComboBox9)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Chart1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "NWXplorer - No File Selected..."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeekViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NoobViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboBox7 As ComboBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ComboBox8 As ComboBox
    Friend WithEvents ComboBox9 As ComboBox
    Friend WithEvents ComboBox10 As ComboBox
    Friend WithEvents ComboBox11 As ComboBox
End Class
