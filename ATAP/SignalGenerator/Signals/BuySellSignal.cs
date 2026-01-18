// <copyright file="BuySellSignal.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalGenerator.Signals;

public record BuySellSignal(DateTime TimeStamp, BuySell BuySell)
    : DataPoint<BuySell>(TimeStamp, BuySell);
