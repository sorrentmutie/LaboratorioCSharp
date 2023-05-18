using System.Net.Mail;

namespace DemoCorsoCSharp.SOLID;

public interface ILogger
{
    void Error(string message);
    void Debug(string message);
    void Info(string message);
}

public class LoggerOnTextFile : ILogger
{
    private readonly string path = @"e://ErrorLog.txt";
    public LoggerOnTextFile()
    {
        
    }

    public void Debug(string message)
    {
        throw new NotImplementedException();
    }

    public void Error(string message)
    {
        System.IO.File.WriteAllText(path, message);
    }

    public void Info(string message)
    {
        throw new NotImplementedException();
    }
}

public class EmailSenderParameters {
    public string? From { get; set; }
}


public class MailSender
{
    private EmailSenderParameters? parameters;
    private string? From;
    //public string? To { get; set; }
    //public string? Subject { get; set; }
    //public string? Body { get; set; }

    public MailSender()
    {
        From = parameters?.From;
    }

    public void SendMail(string To, string Subject, string Body)
    {
        // Qui ci sarà la logica di spedizione
    }
}

public class Invoice
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    private ILogger logger;
    private MailSender emailSender;

    public Invoice(ILogger logger)
    {
        this.logger = logger;
        this.emailSender = new MailSender();
//        logger = new LoggerOnTextFile();
    }

  
    public void AddInvoice()
    {
        // tutta la logica di gestione dell'invoice

        try
        {
            //MailMessage message = new MailMessage("EmailFrom", "EMailTo", "Subject", "Body");
            //SendInvoiceEmail(message);
            //emailSender.Subject = "Subject";
            //emailSender.Body = "";
            //emailSender.From = "";
            //emailSender.To = "";
            emailSender.SendMail("EmailTo", "Subject", "Body");
        }
        catch (Exception ex)
        {
            //System.IO.File.WriteAllText(
            //    @"e://ErrorLog.txt", ex.Message);
            logger.Error(ex.Message);
        }
    }

    public void DeleteInvoice()
    {
        try
        {
            // logica di cancellazione
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            //System.IO.File.WriteAllText(
            //   @"e://ErrorLog.txt", ex.Message); ;
        }
    }


    ////private void SendInvoiceEmail(MailMessage message)
    ////{
    ////    // Useremo il nostro SMTP per mandare email
    ////}
}
