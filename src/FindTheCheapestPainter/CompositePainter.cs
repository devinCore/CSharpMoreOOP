using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheCheapestPainter
{
    //Make it to be a generic class, where it only accepts an IPainter
    class CompositePainter<TPainter> : IPainter
         where TPainter : IPainter
    {
        private IEnumerable<TPainter> Painters { get; }

        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public CompositePainter(IEnumerable<TPainter> painters,
            Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            this.Painters = painters.ToList();
            this.Reduce = reduce;
        }

        //This function is to concrete for a generic type. Solution: Create a delegate
        //private IPainter Reduce(double sqMeters)
        //{
        //    TimeSpan time =
        //        TimeSpan.FromHours(
        //            1 / this.Painters
        //                    .Where(painter => painter.IsAvailable)
        //                    .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
        //                    .Sum()
        //            );

        //    double cost =
        //           1 / this.Painters
        //                   .Where(painter => painter.IsAvailable)
        //                   .Select(painter =>
        //                        painter.EstimateCompensation(sqMeters) /
        //                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
        //                   .Sum();

        //    return new ProportionalPainter()
        //    {
        //        TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
        //        DollarsPerHour = cost / time.TotalHours
        //    };
        //}


        public bool IsAvailable => this.Painters.Any(painter => painter.IsAvailable);

        public double EstimateCompensation(double sqMeters) =>
            this.Reduce(sqMeters, this.Painters).EstimateCompensation(sqMeters);

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters, this.Painters).EstimateTimeToPaint(sqMeters);
    }
}
