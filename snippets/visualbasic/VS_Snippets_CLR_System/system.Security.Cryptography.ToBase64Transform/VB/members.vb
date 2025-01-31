﻿' This sample demonstrates how to use each member of the ToBase64Transform
' class. The file named members.cs is read in and written out as a
' transformed file named members.enc.
'<Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim appPath As String
        appPath = (System.IO.Directory.GetCurrentDirectory() + "\\")

        ' Insert your file names into this method call.
        EncodeFromFile(appPath + "members.vb", appPath + "membersvb.enc")

        ' Reset the cursor and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Read in the specified source file and write out an encoded target file.
    Private Sub EncodeFromFile( _
        ByVal sourceFile As String, _
        ByVal targetFile As String)

        ' Verify members.cs exists at the specified directory.
        If (Not File.Exists(sourceFile)) Then
            tbxOutput.AppendText("Unable to locate source file located at ")
            tbxOutput.AppendText(sourceFile + ". Please correct the path ")
            tbxOutput.AppendText("and run the sample again.")

            Exit Sub
        End If

        ' Retrieve the input and output file streams.
        Dim inputFileStream As New FileStream( _
            sourceFile, FileMode.Open, FileAccess.Read)
        Dim outputFileStream As New FileStream( _
            targetFile, FileMode.Create, FileAccess.Write)

        ' Create a new ToBase64Transform object to convert to base 64.
        '<Snippet2>
        Dim base64Transform As New ToBase64Transform
        '</Snippet2>

        ' Create a new byte array with the size of the output block size.
        '<Snippet6>
        Dim outputBytes(base64Transform.OutputBlockSize) As Byte
        '</Snippet6>

        ' Retrieve the file contents into a byte array.
        Dim inputBytes(inputFileStream.Length) As Byte
        inputFileStream.Read(inputBytes, 0, inputBytes.Length)

        ' Verify that multiple blocks can not be transformed.
        '<Snippet4>
        If (Not base64Transform.CanTransformMultipleBlocks) Then
            '</Snippet4>
            ' Initializie the offset size.
            Dim inputOffset As Integer = 0

            ' Iterate through inputBytes transforming by blockSize.
            '<Snippet8>
            '<Snippet5>
            Dim inputBlockSize As Integer = base64Transform.InputBlockSize
            '</Snippet5>

            While (inputBytes.Length - inputOffset > inputBlockSize)
                base64Transform.TransformBlock( _
                    inputBytes, _
                    inputOffset, _
                    inputBytes.Length - inputOffset, _
                    outputBytes, _
                    0)

                inputOffset += base64Transform.InputBlockSize
                outputFileStream.Write(outputBytes, _
                    0, _
                    base64Transform.OutputBlockSize)
            End While
            '</Snippet8>

            ' Transform the final block of data.
            '<Snippet9>
            outputBytes = base64Transform.TransformFinalBlock( _
                inputBytes, _
                inputOffset, _
                inputBytes.Length - inputOffset)
            '</Snippet9>

            outputFileStream.Write(outputBytes, 0, outputBytes.Length)
            tbxOutput.AppendText("Created encoded file at " + targetFile)
        End If

        ' Determine if the current transform can be reused.
        '<Snippet3>
        If (Not base64Transform.CanReuseTransform) Then
            '</Snippet3>
            ' Free up any used resources.
            '<Snippet7>
            base64Transform.Clear()
            '</Snippet7>
        End If

        ' Close file streams.
        inputFileStream.Close()
        outputFileStream.Close()
    End Sub

    ' Event handler for Exit button.
    Private Sub Button2_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Application.Exit()
    End Sub
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbxOutput As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbxOutput = New System.Windows.Forms.RichTextBox
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.DockPadding.All = 20
        Me.Panel2.Location = New System.Drawing.Point(0, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 64)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(446, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Run"
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(521, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "E&xit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbxOutput)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.DockPadding.All = 20
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 320)
        Me.Panel1.TabIndex = 2
        '
        'tbxOutput
        '
        Me.tbxOutput.AccessibleDescription = _
            "Displays output from application."
        Me.tbxOutput.AccessibleName = "Output textbox."
        Me.tbxOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxOutput.Location = New System.Drawing.Point(20, 20)
        Me.tbxOutput.Name = "tbxOutput"
        Me.tbxOutput.Size = New System.Drawing.Size(576, 280)
        Me.tbxOutput.TabIndex = 1
        Me.tbxOutput.Text = "Click the Run button to run the application."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(616, 384)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form1"
        Me.Text = "ToBase64Transform"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Created encoded file at C:\WindowsApplication1\\membersvb.enc
' This sample completed successfully; press Exit to continue.
'</Snippet1>