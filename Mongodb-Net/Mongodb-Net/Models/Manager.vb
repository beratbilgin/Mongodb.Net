﻿Imports MongoDB.Driver


Namespace Connect


    Public Class Manager
        Implements IDisposable

        Private Disposed As Boolean = False
        Private ConnectionString = "server=ds047107.mongolab.com:47107;database=sanatcidb;safe=true;username=SanatciAdmin;Password=123456"
        Private Builder = New MongoConnectionStringBuilder(ConnectionString)

        Private Server As MongoServer = MongoServer.Create(Builder)
        Private db As MongoDatabase = Server("sanatcidb")

        Public Function GetArtists() As IEnumerable(Of Sanatci)
            Try
                Dim Collection As MongoCollection(Of Sanatci) = GetArtistsCollection()
                Return Collection.FindAll().ToList
            Catch generatedExceptionName As MongoConnectionException
                Return New List(Of Sanatci)()
            End Try
        End Function

        Public Function CreateArtist(s As Sanatci) As Boolean
            Dim Collection As MongoCollection(Of Sanatci) = GetArtistsCollection()
            Try
                Return Collection.Insert(s, SafeMode.True).Ok
            Catch ex As MongoCommandException
                Dim msgLog As String = ex.Message
                Return False
            End Try
        End Function

        Private Function GetArtistsCollection() As MongoCollection(Of Sanatci)
            Dim Collection As MongoCollection(Of Sanatci) = db.GetCollection(Of Sanatci)("Sanatci")
            Return Collection
        End Function


#Region "IDisposable"

        Public Sub Dispose() Implements IDisposable.Dispose
            Me.Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.Disposed Then
                If disposing Then
                    If Server IsNot Nothing Then
                        Me.Server.Disconnect()
                    End If
                End If
            End If

            Me.Disposed = True
        End Sub

#End Region

    End Class


End Namespace