﻿using System;
using DDDCinema.Common;

namespace DDDCinema.Application.Movies
{
	public class ReserveSeatCommand : ICommand
	{
		public int SeanseId { get; set; }
		public int SeatNumber { get; set; }
		public int SeatRow { get; set; }
		public Guid UserId { get; set; }
	}
}
