using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public record MultiTimeSeries<T>(IReadOnlyList<string> Names, TimeSeries<List<T>> UnderlyingTimeSeries);
