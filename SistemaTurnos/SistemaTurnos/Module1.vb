Imports MailBee.SmtpMail
Module Module1
    Public ModoTest As Boolean = False
    Public NuevoLayer As Integer = 0
    Public NroLocal As Integer
    Public NombreLocal As String
    Public CupoLocal As Integer
    Public TelLocal As String
    Public cuerpoMailstring As String
    Public horarioLocal As String
    Public Sub Sendmail(subject As String, provider As String, adjunto As String)
        Dim mailer As New Smtp()
        Try
            mailer.SmtpServers.Add("181.30.5.237", "sistemas", "lobito1.2016")
            If ModoTest Then
                mailer.Message.From.AsString = "programadormtg@montagne.com.ar"
                mailer.Message.To.AsString = "programadormtg@montagne.com.ar, matiassperk@montagne.com.ar"
            Else
                mailer.Message.From.AsString = "eventomontagne@montagne.com.ar"
                mailer.Message.To.AsString = provider
            End If
            mailer.Message.Subject = subject
            mailer.Message.BodyHtmlText = cuerpoMailstring
            mailer.AddAttachment(adjunto)
            mailer.Send()
        Catch ex As Exception
            MsgBox("Ha ocurrido un error al enviar el correo.", vbOKOnly + vbExclamation, "Atencion")
        End Try
    End Sub
End Module