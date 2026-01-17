// <copyright file="DtoContainer.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Dto;

public record DtoContainer<T>(IReadOnlyList<T> Dtos);