using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    // KLASA DO PRZECHOWYWANIA POJEDYNCZEJ OBSERWACJI POGODY KOSMICZNEJ
    public class SpaceWeather
    {
        public int IdSpace { get; set; }
        public string EventId { get; set; }
        public string EventType { get; set; }
        public string? BeginTime { get; set; }
        public string? PeakTime { get; set; }
        public string? EndTime { get; set; }
        public string? ClassType { get; set; }
        public string? SourceLocation { get; set; }
        public string? ActiveRegion { get; set; }
        public string? Instruments { get; set; }
        public string? Note { get; set; }
        public string? KpIndex { get; set; }
        public string? ObservedTime { get; set; }
        public string? Source { get; set; }
        public DateOnly Date { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Hour { get; set; }
    }

    // Rekord reprezentujący jeden wiersz z tabeli spaceweathercombined
    public record SpaceWeatherCombined(
        int IdSpace,
        string EventId,
        string EventType,
        string? BeginTime,
        string? PeakTime,
        string? EndTime,
        string? ClassType,
        string? SourceLocation,
        string? ActiveRegion,
        string? Instruments,
        string? Note,
        DateOnly Date
        );
}
