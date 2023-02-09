using FlightRepositories.Data;
using FlightRepositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRepositories
{
    public interface IFlightRepository
    {
        List<FlightDTO> GetFlights();
        List<AirlinesTicketsChennaiToMumbai> PostFlights(AirlinesTicketsChennaiToMumbai newAir);
        AirlinesTicketsChennaiToMumbai DeleteFlights(short id);
        AirlinesTicketsChennaiToMumbai UpdateFlightStatus(short id);
    }
}
