using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAggregator.Models;

namespace TicketsAggregator.Writers;
internal abstract class TicketsWriter : ITicketsWriter
{
    protected string _fileName;
    public TicketsWriter(string fileName)
    {
        _fileName = fileName; 
    }

    public virtual void Write(string fileName, List<Ticket> tickets, CultureInfo? cultureInfo = null)
    {
        throw new NotImplementedException();
    }
}
