Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private AllowUpdates As Boolean = True
    Private Class LogEntry
        Private Rank As String
        Private WhenWho As String
        Private WhoID As String
        Private Entity As String
        Private EntityID As String
        Private Target As String
        Private TargetID As String
        Private Action As String
        Private ActionID As String
        Private Effects As String
        Private Flags As String
        Private Amount As String
        Private Mitigate As String

        Public Function _load(ByVal data As List(Of String)) As LogEntry
            Dim fucky As New LogEntry
            If (data.Count = 13) Then
                For i As Integer = 0 To 12
                    fucky._set(i, data(i))
                Next
            End If
            _load = fucky
        End Function

        Public Function _get(ByVal what As Integer) As String
            Select Case what
                Case Is = 0
                    _get = Rank
                Case Is = 1
                    _get = WhenWho
                Case Is = 2
                    _get = WhoID
                Case Is = 3
                    _get = Entity
                Case Is = 4
                    _get = EntityID
                Case Is = 5
                    _get = Target
                Case Is = 6
                    _get = TargetID
                Case Is = 7
                    _get = Action
                Case Is = 8
                    _get = ActionID
                Case Is = 9
                    _get = Effects
                Case Is = 10
                    _get = Flags
                Case Is = 11
                    _get = Amount
                Case Is = 12
                    _get = Mitigate
                Case Else
                    _get = "Unknown Request"
            End Select
        End Function

        Public Sub _set(ByVal what As Integer, ByVal data As String)
            Select Case what
                Case Is = 0
                    Rank = data
                Case Is = 1
                    WhenWho = data
                Case Is = 2
                    WhoID = data
                Case Is = 3
                    Entity = data
                Case Is = 4
                    EntityID = data
                Case Is = 5
                    Target = data
                Case Is = 6
                    TargetID = data
                Case Is = 7
                    Action = data
                Case Is = 8
                    ActionID = data
                Case Is = 9
                    Effects = data
                Case Is = 10
                    Flags = data
                Case Is = 11
                    Amount = data
                Case Is = 12
                    Mitigate = data
            End Select
        End Sub

        Public Function _getSex(Optional ByVal fakeSex As String = "") As Single
            Dim a_minute As Integer = 60
            Dim a_hour As Integer = a_minute * 60
            Dim a_day As Integer = a_hour * 24
            Dim dhms As String()
            If (fakeSex = "") Then
                dhms = _get(1).Split(":").Take(6).ToArray()
            Else
                dhms = fakeSex.Split(":").Take(6).ToArray()
            End If
            Dim total_sex As Single = 0
            For i As Integer = 2 To 5
                Select Case i
                    Case = 2
                        total_sex = total_sex + (CInt(dhms(i)) * a_day)
                    Case = 3
                        total_sex = total_sex + (CInt(dhms(i)) * a_hour)
                    Case = 4
                        total_sex = total_sex + (CInt(dhms(i)) * a_minute)
                    Case = 5
                        total_sex = total_sex + CSng(dhms(i))
                End Select
            Next
            _getSex = total_sex
        End Function
    End Class

    Private ViewMode As Integer
    Private The_Data_List As List(Of LogEntry)

    Private Sub ShowRawData()
        ListView1.Columns.Add("Item", 100)
        ListView1.Columns.Add("When/Who", 200)
        ListView1.Columns.Add("ID", 300)
        ListView1.Columns.Add("Entity", 200)
        ListView1.Columns.Add("Entity ID", 300)
        ListView1.Columns.Add("Recipient", 100)
        ListView1.Columns.Add("Recipient ID", 300)
        ListView1.Columns.Add("Action", 100)
        ListView1.Columns.Add("Action ID", 100)
        ListView1.Columns.Add("Effects", 100)
        ListView1.Columns.Add("Flags", 100)
        ListView1.Columns.Add("Amount", 100)
        For Each this_item As LogEntry In The_Data_List.AsEnumerable
            Dim lvi As ListViewItem = Log2List(this_item)
            ListView1.Items.Add(lvi)
        Next
    End Sub

    Private Function ReadLog(ByVal fname As String) As List(Of LogEntry)
        Dim temp_list As List(Of LogEntry)
        temp_list = New List(Of LogEntry)
        Using NWReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(fname)
            NWReader.TextFieldType = FileIO.FieldType.Delimited
            NWReader.SetDelimiters(",")
            Dim this_item As Integer = 0
            While Not NWReader.EndOfData
                Dim this_row As New List(Of String)
                Try
                    this_row.Add(this_item)
                    Dim bullshit As String()
                    bullshit = NWReader.ReadFields()
                    this_row.AddRange(bullshit)
                    Dim new_item As New LogEntry
                    new_item = new_item._load(this_row)
                    temp_list.Add(new_item)
                    this_item += 1
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    Debug.Print("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
            Debug.Print("Found " & this_item & " items.")
        End Using
        ReadLog = temp_list
    End Function

    Private Sub LoadFile()
        Dim filer As String = ""
        If (ComboBox2.SelectedIndex = 0) Then
            OpenFileDialog1.ShowDialog()
            filer = OpenFileDialog1.FileName
        ElseIf (ComboBox2.SelectedIndex = 1) Then
            FolderBrowserDialog1.ShowDialog()
            Dim search_folder As String = FolderBrowserDialog1.SelectedPath
            If (IO.Directory.Exists(search_folder)) Then
                Dim workdir = New IO.DirectoryInfo(search_folder)
                Dim files = workdir.EnumerateFiles("Combat*.log")
                Dim newest As Date = Nothing
                Dim newfile As IO.FileInfo = Nothing
                For Each ffs In files
                    Dim wtf2 As Date = ffs.LastWriteTime()
                    If ((wtf2.CompareTo(newest) > 0) Or (newest = Nothing)) Then
                        newest = wtf2
                        newfile = ffs
                    End If
                Next
                If ((newest = Nothing) Or (newfile Is Nothing)) Then
                    MsgBox("No Combat Logs Found!!!")
                Else
                    filer = newfile.FullName
                End If
            End If
        End If
        If (IO.File.Exists(filer)) Then
            AllowUpdates = False
            Dim titlevar As String() = filer.Split("\")
            Dim lastvar As Integer = titlevar.Count() - 1
            Me.Text = "NWXplorer - " & titlevar(lastvar)
            TextBox1.Text = filer
            The_Data_List = New List(Of LogEntry)
            The_Data_List = ReadLog(filer)
            LoadExpertBoxes()
            ComboBox7.SelectedIndex = 0
            ComboBox7.Enabled = True
            ComboBox8.SelectedIndex = 0
            ComboBox8.Enabled = True
            AllowUpdates = True
#If DEBUG Then
            ComboBox1.Items.Add("Raw Data")
#End If
            ComboBox1.SelectedIndex = 0
            ComboBox1.Enabled = True
        Else
            TextBox1.Text = "No File Selected..."
        End If
    End Sub

    Private Function Log2List(ByVal ldata As LogEntry) As ListViewItem
        Dim lvi As New ListViewItem("Action #" & ldata._get(0))
        For i As Integer = 1 To 11
            lvi.SubItems.Add(ldata._get(i))
        Next
        Log2List = lvi
    End Function

    Private Sub LoadExpertBoxes()
        Dim AttackList As New List(Of String)
        Dim ActionList As New List(Of String)
        Dim TargetList As New List(Of String)
        For Each this_item As LogEntry In The_Data_List.AsEnumerable
            Dim this_action As String = this_item._get(9).Trim(" ")
            Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
            Dim this_target As String = this_item._get(5).Trim(" ")
            If (this_target = "") Then
                this_target = "Self"
            End If
            If (this_name = "") Then
                this_name = "Unknown"
            End If
            If (AttackList.IndexOf(this_name) = -1) Then
                AttackList.Add(this_name)
            End If
            If (ActionList.IndexOf(this_action) = -1) Then
                ActionList.Add(this_action)
            End If
            If (TargetList.IndexOf(this_target) = -1) Then
                TargetList.Add(this_target)
            End If
        Next
        AttackList.Add("All Attackers")
        ActionList.Add("All Actions")
        TargetList.Add("All Targets")
        AttackList.Sort()
        ActionList.Sort()
        TargetList.Sort()
        ComboBox3.Items.AddRange(AttackList.ToArray())
        ComboBox4.Items.AddRange(ActionList.ToArray())
        ComboBox5.Items.AddRange(TargetList.ToArray())
        ComboBox3.SelectedIndex = ComboBox3.Items.IndexOf("All Attackers")
        ComboBox4.SelectedIndex = ComboBox4.Items.IndexOf("All Actions")
        ComboBox5.SelectedIndex = ComboBox5.Items.IndexOf("All Targets")
        ComboBox6.SelectedIndex = ComboBox6.Items.IndexOf("Itemized")
    End Sub

    Private Sub CustomSort()
        ListView1.Clear()
        ListView1.Columns.Add("Attacker", 150)
        ListView1.Columns.Add("Action", 150)
        ListView1.Columns.Add("Target", 150)
        ListView1.Columns.Add("Amount", 150)
        Dim who_q As String = ComboBox3.Text
        Dim what_q As String = ComboBox4.Text
        Dim where_q As String = ComboBox5.Text
        Dim a_tracker As New Dictionary(Of String, String)
        For Each this_log As LogEntry In The_Data_List.AsEnumerable
            Dim who_l As String = this_log._get(1).Split(":")(7).Trim(" ")
            If (who_l = "") Then
                who_l = "Unknown"
            End If
            Dim where_l As String = this_log._get(5)
            If (where_l = "") Then
                where_l = "Self"
            End If
            Dim what_l As String = this_log._get(9)
            Dim amount As String = Math.Abs(Int(this_log._get(11)))
            Dim mitigate As String = Math.Abs(Int(this_log._get(12)))
            If (who_l = who_q) Or (who_q = "All Attackers") Then
                If (where_l = where_q) Or (where_q = "All Targets") Then
                    If (what_l = what_q) Or (what_q = "All Actions") Then
                        If (ComboBox6.SelectedIndex <= 0) Then
                            Dim temp As New ListViewItem(who_l)
                            temp.SubItems.Add(what_l)
                            temp.SubItems.Add(where_l)
                            temp.SubItems.Add(amount & " (Mitigate:" & mitigate & ")")
                            ListView1.Items.Add(temp)
                        Else
                            Dim l_key As String = who_l & "," & what_l & "," & where_l
                            Dim this_much As String = "0"
                            If (a_tracker.TryGetValue(l_key, this_much)) Then
                                Dim a_m As String() = this_much.Split(",")
                                Dim a As Integer = Int(a_m(0))
                                Dim m As Integer = Int(a_m(1))
                                a = a + amount
                                m = m + mitigate
                                a_tracker.Item(l_key) = a & "," & m
                            Else
                                a_tracker.Add(l_key, amount & "," & mitigate)
                            End If
                        End If
                    End If
                End If
            End If
        Next
        If (ComboBox6.SelectedIndex = 1) Then
            Dim sorted = From pair In a_tracker Order By pair.Value Descending
            Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
            For Each encoded_log In sortdic
                Dim www As String() = encoded_log.Key.Split(",")
                Dim a_m As String() = encoded_log.Value.Split(",")
                Dim temp As New ListViewItem(www(0))
                temp.SubItems.Add(www(1))
                temp.SubItems.Add(www(2))
                temp.SubItems.Add(a_m(0) & " (Mitigate: " & a_m(1) & ")")
                ListView1.Items.Add(temp)
            Next
        End If
    End Sub

    Private Sub UpdateList()
        ListView1.Clear()
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        ComboBox6.Enabled = False
        Select Case ComboBox1.SelectedIndex
            Case = ComboBox1.Items.IndexOf("Player Damage (Total)")
                Dim counter As Integer = 0
                ListView1.Columns.Add("Attacker", 200)
                ListView1.Columns.Add("Damage", 200)
                Dim dmg_data As New Dictionary(Of String, Integer)
                For Each this_item As LogEntry In The_Data_List.AsEnumerable
                    Dim this_action As String = this_item._get(9)
                    Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
                    Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
                    If ((this_name <> "") And (this_type = "P") And (this_action = "Physical")) Then
                        Dim this_hurt As Integer = CInt(this_item._get(11))
                        If (this_hurt <> 0) Then
                            Dim total_hurt As Integer = 0
                            If (dmg_data.TryGetValue(this_name, total_hurt)) Then
                                dmg_data.Item(this_name) = this_hurt + total_hurt
                            Else
                                dmg_data.Add(this_name, this_hurt)
                            End If
                        End If
                    End If
                Next
                Dim sorted = From pair In dmg_data Order By pair.Value Descending
                Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
                For Each person In sortdic
                    Dim this As New ListViewItem(person.Key)
                    this.SubItems.Add(person.Value)
                    ListView1.Items.Add(this)
                Next
            Case = ComboBox1.Items.IndexOf("NPC Damage (Total)")
                Dim counter As Integer = 0
                ListView1.Columns.Add("Attacker", 200)
                ListView1.Columns.Add("Damage", 200)
                Dim dmg_data As New Dictionary(Of String, Integer)
                For Each this_item As LogEntry In The_Data_List.AsEnumerable
                    Dim this_action As String = this_item._get(9)
                    Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
                    Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
                    If ((this_name <> "") And (this_type = "C") And (this_action = "Physical")) Then
                        Dim this_hurt As Integer = CInt(this_item._get(11))
                        If (this_hurt <> 0) Then
                            Dim total_hurt As Integer = 0
                            If (dmg_data.TryGetValue(this_name, total_hurt)) Then
                                dmg_data.Item(this_name) = this_hurt + total_hurt
                            Else
                                dmg_data.Add(this_name, this_hurt)
                            End If
                        End If
                    End If
                Next
                Dim sorted = From pair In dmg_data Order By pair.Value Descending
                Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
                For Each person In sortdic
                    Dim this As New ListViewItem(person.Key)
                    this.SubItems.Add(person.Value)
                    ListView1.Items.Add(this)
                Next
            Case = ComboBox1.Items.IndexOf("Player Healing (Total)")
                Dim counter As Integer = 0
                ListView1.Columns.Add("Healer", 200)
                ListView1.Columns.Add("Healing", 200)
                Dim dmg_data As New Dictionary(Of String, Integer)
                For Each this_item As LogEntry In The_Data_List.AsEnumerable
                    Dim this_action As String = this_item._get(9)
                    Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
                    Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
                    Dim this_whoid As String = this_item._get(6).Split("[")(0).Trim(" ")
                    If ((this_action = "HitPoints") And (this_name <> "") And (this_type = "P") And ((this_whoid = "P") Or (this_whoid = "*"))) Then
                        Dim this_hurt As Integer = Math.Abs(CInt(this_item._get(11)))
                        If (this_hurt > 0) Then
                            Dim total_hurt As Integer = 0
                            If (dmg_data.TryGetValue(this_name, total_hurt)) Then
                                dmg_data.Item(this_name) = this_hurt + total_hurt
                            Else
                                dmg_data.Add(this_name, this_hurt)
                            End If
                        End If
                    End If
                Next
                Dim sorted = From pair In dmg_data Order By pair.Value Descending
                Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
                For Each person In sortdic
                    Dim this As New ListViewItem(person.Key)
                    this.SubItems.Add(person.Value)
                    ListView1.Items.Add(this)
                Next
            Case = ComboBox1.Items.IndexOf("Player Damage (Target)")
                Dim counter As Integer = 0
                ListView1.Columns.Add("Attacker", 200)
                ListView1.Columns.Add("Target", 200)
                ListView1.Columns.Add("Damage", 200)
                Dim dmg_data As New Dictionary(Of String, Integer)
                For Each this_item As LogEntry In The_Data_List.AsEnumerable
                    Dim this_action As String = this_item._get(9)
                    Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
                    Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
                    If ((this_action = "Physical") And (this_type = "P") And (this_name <> "")) Then
                        Dim versus As String = this_name & "," & this_item._get(5)
                        Dim this_hurt As Integer = CInt(this_item._get(11))
                        If (this_hurt <> 0) Then
                            Dim total_hurt As Integer = 0
                            If (dmg_data.TryGetValue(versus, total_hurt)) Then
                                dmg_data.Item(versus) = this_hurt + total_hurt
                            Else
                                dmg_data.Add(versus, this_hurt)
                            End If
                        End If
                    End If
                Next
                Dim sorted = From pair In dmg_data Order By pair.Value Descending
                Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
                For Each person In sortdic
                    Dim this As New ListViewItem(person.Key.Split(",")(0))
                    this.SubItems.Add(person.Key.Split(",")(1))
                    this.SubItems.Add(person.Value)
                    ListView1.Items.Add(this)
                Next
            Case = ComboBox1.Items.IndexOf("NPC Damage (Target)")
                Dim counter As Integer = 0
                ListView1.Columns.Add("Attacker", 200)
                ListView1.Columns.Add("Target", 200)
                ListView1.Columns.Add("Damage", 200)
                Dim dmg_data As New Dictionary(Of String, Integer)
                For Each this_item As LogEntry In The_Data_List.AsEnumerable
                    Dim this_action As String = this_item._get(9)
                    Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
                    Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
                    If ((this_action = "Physical") And (this_type = "C") And (this_name <> "")) Then
                        Dim versus As String = this_name & "," & this_item._get(5)
                        Dim this_hurt As Integer = CInt(this_item._get(11))
                        If (this_hurt <> 0) Then
                            Dim total_hurt As Integer = 0
                            If (dmg_data.TryGetValue(versus, total_hurt)) Then
                                dmg_data.Item(versus) = this_hurt + total_hurt
                            Else
                                dmg_data.Add(versus, this_hurt)
                            End If
                        End If
                    End If
                Next
                Dim sorted = From pair In dmg_data Order By pair.Value Descending
                Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
                For Each person In sortdic
                    Dim this As New ListViewItem(person.Key.Split(",")(0))
                    this.SubItems.Add(person.Key.Split(",")(1))
                    this.SubItems.Add(person.Value)
                    ListView1.Items.Add(this)
                Next
            Case = ComboBox1.Items.IndexOf("Player Healing (Target)")
                Dim counter As Integer = 0
                ListView1.Columns.Add("Healer", 200)
                ListView1.Columns.Add("Target", 200)
                ListView1.Columns.Add("Healing", 200)
                Dim dmg_data As New Dictionary(Of String, Integer)
                For Each this_item As LogEntry In The_Data_List.AsEnumerable
                    Dim this_action As String = this_item._get(9)
                    Dim this_name As String = this_item._get(1).Split(":")(7).Trim(" ")
                    Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
                    Dim this_whoid As String = this_item._get(6).Split("[")(0).Trim(" ")
                    If ((this_action = "HitPoints") And (this_name <> "") And (this_type = "P") And ((this_whoid = "P") Or (this_whoid = "*"))) Then
                        Dim this_hurt As Integer = Math.Abs(CInt(this_item._get(11)))
                        If (this_hurt > 0) Then
                            Dim total_hurt As Integer = 0
                            Dim target As String = this_item._get(5)
                            If (target = "") Then
                                target = "Self (" & this_item._get(7) & ")"
                            End If
                            Dim versus As String = this_name & "," & target
                            If (dmg_data.TryGetValue(versus, total_hurt)) Then
                                dmg_data.Item(versus) = this_hurt + total_hurt
                            Else
                                dmg_data.Add(versus, this_hurt)
                            End If
                        End If
                    End If
                Next
                Dim sorted = From pair In dmg_data Order By CInt(pair.Value.ToString.Split(",")(0)) Descending
                Dim sortdic = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
                For Each person In sortdic
                    Dim this As New ListViewItem(person.Key.Split(",")(0))
                    this.SubItems.Add(person.Key.Split(",")(1))
                    this.SubItems.Add(person.Value)
                    ListView1.Items.Add(this)
                Next
            Case = ComboBox1.Items.IndexOf("Custom...")
                CustomSort()
                ComboBox3.Enabled = True
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
                ComboBox6.Enabled = True
            Case = ComboBox1.Items.IndexOf("Raw Data")
                ShowRawData()
        End Select
        ListView1.Refresh()
    End Sub

    Private Sub UpdateChart()
        If (The_Data_List Is Nothing) Then
            Exit Sub
        End If
        Dim colorTable As Color() = {Color.Black, Color.Gray, Color.Green, Color.Orange, Color.Pink, Color.Yellow, Color.Blue, Color.Purple, Color.LightBlue, Color.Red}
        Dim test_action As String = "Physical"
        If (ComboBox7.SelectedIndex = 0) Then
            Chart1.Text = "Damage Over Time"
            Chart1.Titles.Item(0).Text = "Damage"
        Else
            test_action = "HitPoints"
            Chart1.Text = "Healing Over Time"
            Chart1.Titles.Item(0).Text = "Healing"
        End If
        Dim high_damage As Integer = 0
        Dim damage_data As New Dictionary(Of String, Integer)
        Dim series_data As New Dictionary(Of String, Boolean)
        For Each this_item As LogEntry In The_Data_List.AsEnumerable
            Dim this_name As String = this_item._get(1)
            Dim this_action As String = this_item._get(9)
            Dim this_type As String = this_item._get(2).Split("[")(0).Trim(" ")
            If ((this_name <> "") And (this_type = "P") And (this_action = test_action)) Then
                Dim exists As Boolean
                Dim who As String = this_name.Split(":")(7)
                If ((ComboBox8.SelectedIndex = 0) Or ((ComboBox8.SelectedIndex = 1) And (who = ComboBox9.Text Or who = ComboBox10.Text Or who = ComboBox11.Text))) Then
                    If Not (series_data.TryGetValue(who, exists)) Then
                        series_data.Add(who, True)
                    End If
                    Dim the_hurt As Integer = 0
                    Dim this_hurt As Integer = Math.Abs(CInt(this_item._get(11)))
                    If (damage_data.TryGetValue(this_name, the_hurt)) Then
                        damage_data.Item(this_name) = the_hurt + this_hurt
                    Else
                        damage_data.Add(this_name, this_hurt)
                    End If
                    If ((the_hurt + this_hurt) > high_damage) Then
                        high_damage = the_hurt + this_hurt
                    End If
                End If
            End If
        Next
        high_damage = high_damage * 1.2
        Dim start_sex As Single = The_Data_List.ToArray()(0)._getSex()
        Dim last_sex As Single = The_Data_List.ToArray()(The_Data_List.Count - 1)._getSex()
        Chart1.Series.Clear()
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.Maximum = last_sex - start_sex
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = high_damage
        Dim colorcounter As Integer = 0
        For Each player In series_data
            Chart1.Series.Add(New Series(player.Key) With {.ChartType = SeriesChartType.Line, .Color = colorTable(colorcounter), .MarkerStyle = MarkerStyle.Circle, .MarkerSize = 10, .ToolTip = "#VALX: #SERIESNAME - #VALY"})
            For Each fight_event In damage_data
                If (fight_event.Key.Split(":")(7) = player.Key) Then
                    Dim rel_time As Single = The_Data_List.Item(0)._getSex(fight_event.Key) - start_sex
                    Chart1.Series(player.Key).Points.AddXY(rel_time, fight_event.Value)
                End If
            Next
            colorcounter += 1
        Next
    End Sub

    Private Sub LoadPlayerBoxes()
        Dim NameList As List(Of String) = New List(Of String)
        ComboBox9.Items.Add("None")
        ComboBox10.Items.Add("None")
        ComboBox11.Items.Add("None")
        For Each this_item As LogEntry In The_Data_List.AsEnumerable
            Dim this_name As String = this_item._get(1).Split(":")(7)
            If (Not NameList.Contains(this_name)) And (this_item._get(2).Split("[")(0).Trim(" ") = "P") Then
                NameList.Add(this_name)
                ComboBox9.Items.Add(this_name)
                ComboBox10.Items.Add(this_name)
                ComboBox11.Items.Add(this_name)
            End If
        Next
    End Sub

    Private Sub DoNoobView()
        ListView1.Hide()
        ListView1.SendToBack()
        ComboBox1.Hide()
        ComboBox1.SendToBack()
        ComboBox3.Hide()
        ComboBox3.SendToBack()
        ComboBox4.Hide()
        ComboBox4.SendToBack()
        ComboBox5.Hide()
        ComboBox5.SendToBack()
        ComboBox6.Hide()
        ComboBox6.SendToBack()
        Chart1.Show()
        Chart1.BringToFront()
        ComboBox7.Show()
        ComboBox7.BringToFront()
        ComboBox8.Show()
        ComboBox8.BringToFront()
        ComboBox9.Show()
        ComboBox9.BringToFront()
        ComboBox10.Show()
        ComboBox10.BringToFront()
        ComboBox11.Show()
        ComboBox11.BringToFront()
        UpdateChart()
        ViewMode = 1
    End Sub

    Private Sub DoGeekView()
        Chart1.Hide()
        Chart1.SendToBack()
        ComboBox7.Hide()
        ComboBox7.SendToBack()
        ComboBox8.Hide()
        ComboBox8.SendToBack()
        ComboBox9.Hide()
        ComboBox9.SendToBack()
        ComboBox10.Hide()
        ComboBox10.SendToBack()
        ComboBox11.Hide()
        ComboBox11.SendToBack()
        ListView1.Show()
        ListView1.BringToFront()
        ComboBox1.Show()
        ComboBox1.BringToFront()
        ComboBox3.Show()
        ComboBox3.BringToFront()
        ComboBox4.Show()
        ComboBox4.BringToFront()
        ComboBox5.Show()
        ComboBox5.BringToFront()
        ComboBox6.Show()
        ComboBox6.BringToFront()
        ViewMode = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadFile()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If (ViewMode <> 0) Then Exit Sub
        UpdateList()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewMode = -1
        ComboBox2.Hide()
        ComboBox2.SendToBack()
        ComboBox2.SelectedIndex = 0
        GeekViewToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub Form1_resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ListView1.Width = Me.Width - 43
        ListView1.Height = Me.Height - 150
        Chart1.Width = Me.Width - 43
        Chart1.Height = Me.Height - 150
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ListView1.Clear()
        If (ComboBox2.SelectedIndex = 1) Then
            Label1.Text = "Log Folder:"
            TextBox1.Text = "No folder selected..."
        Else
            Label1.Text = "Log File:"
            TextBox1.Text = "No file selected..."
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If AllowUpdates Then
            CustomSort()
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If AllowUpdates Then
            CustomSort()
        End If
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        If AllowUpdates Then
            CustomSort()
        End If
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If AllowUpdates Then
            CustomSort()
        End If
    End Sub

    Private Sub GeekViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeekViewToolStripMenuItem.Click
        If (ViewMode <> 0) Then
            DoGeekView()
        End If
    End Sub

    Private Sub NoobViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoobViewToolStripMenuItem.Click
        If (ViewMode <> 1) Then
            DoNoobView()
        End If
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        If (ViewMode <> 1) Then Exit Sub
        UpdateChart()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        Select Case ComboBox8.SelectedIndex
            Case Is = 0
                ComboBox9.Enabled = False
                ComboBox10.Enabled = False
                ComboBox11.Enabled = False
            Case Is = 1
                ComboBox9.Enabled = True
                ComboBox10.Enabled = True
                ComboBox11.Enabled = True
                LoadPlayerBoxes()
        End Select
        UpdateChart()
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        UpdateChart()
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        UpdateChart()
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedIndexChanged
        UpdateChart()
    End Sub
End Class
