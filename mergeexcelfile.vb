Sub MergeExcelFiles()
Dim MyPath, MyName, AWbName
Dim Wb As Workbook, WbN As String
Dim G As Long
Dim Num, ini As Long
Application.ScreenUpdating = False
MyPath = ActiveWorkbook.Path
MyName = Dir(MyPath & "\" & "*.xls")
AWbName = ActiveWorkbook.Name
Num = 0
ini = 0
Do While MyName <> ""
If MyName <> AWbName Then
Set Wb = Workbooks.Open(MyPath & "\" & MyName)
Num = Num + 1
With Workbooks(1).ActiveSheet
If ini = 0 Then
Wb.Sheets(1).Range(Wb.Sheets(1).Cells(1, 1), Wb.Sheets(1).Cells(1, Wb.Sheets(1).UsedRange.Columns.Count)).Copy .Cells(1, 1)
ini = 1
End If
For G = 1 To Sheets.Count
Wb.Sheets(G).Range(Wb.Sheets(G).Cells(1, 1), Wb.Sheets(G).Cells(Wb.Sheets(G).UsedRange.Rows.Count, Wb.Sheets(G).UsedRange.Columns.Count)).Copy .Cells(.Range("A65536").End(xlUp).Row + 1, 1)
Next
WbN = WbN & Chr(13) & Wb.Name
Wb.Close False
End With
End If
MyName = Dir
Loop
Range("A1").Select
Application.ScreenUpdating = True
MsgBox "共合并了" & Num & "个工作薄下的全部工作表。如下:" & Chr(13) & WbN, vbInformation, "提示"
End Sub
