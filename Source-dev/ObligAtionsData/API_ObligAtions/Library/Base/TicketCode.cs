using System.Reflection;

namespace Library.Base;

public static class TicketCode
{
    private static readonly Random rnd = new Random(10);

    /// <summary>
    /// Render ra mã Ticket
    /// </summary>
    /// <param name="Ticket">Tên Ticket</param>
    /// <returns>Mã</returns>
    public static string RenderCode(string Ticket)
    {
        string TicketCode = string.Format("{0}{1}", Ticket, rnd.Next());
        return TicketCode;
    }
}
