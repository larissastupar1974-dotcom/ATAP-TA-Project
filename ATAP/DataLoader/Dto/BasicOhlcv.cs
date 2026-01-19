using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.Dto;

public record BasicOhlcv(DateTime Timestamp, double? Open, double? High, double? Low, double? Close, double Volume);
