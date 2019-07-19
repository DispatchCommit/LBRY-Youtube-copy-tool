﻿Imports System.IO
Imports System.Text

Namespace ProxyChecker
    Public Class Writer
        Private Shared ReadOnly locker As Object = New Object()
        Public Property FilePath As String

        Public Sub AppendToFile(ByVal textToAppend As String)
            SyncLock Writer.locker

                Using fileStream As FileStream = New FileStream(Me.FilePath, FileMode.Append, FileAccess.Write, FileShare.Read)

                    Using streamWriter As StreamWriter = New StreamWriter(CType(fileStream, Stream), Encoding.Unicode)
                        streamWriter.WriteLine(textToAppend)
                        streamWriter.Close()
                        streamWriter.Dispose()
                    End Using
                End Using

            End SyncLock
        End Sub
    End Class
End Namespace
