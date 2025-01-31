﻿Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    ' <Snippet1>
    ' Class-level declaration.
    ' Create a TraceSwitch.
    Private Shared generalSwitch As New TraceSwitch("General", "Entire Application")
    
    
    Public Shared Sub MyErrorMethod(myObject As Object)
        ' Write the message if the TraceSwitch level is set to Error or higher.
        If generalSwitch.TraceError Then
            Debug.Write("Invalid object. ")
        End If 
        ' Write a second message if the TraceSwitch level is set to Verbose.
        If generalSwitch.TraceVerbose Then
            Debug.WriteLine(myObject)
        End If
    End Sub 'MyErrorMethod 
    ' </Snippet1>
End Class 'Form1 
