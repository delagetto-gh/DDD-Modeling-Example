﻿using System.Collections.Generic;

namespace DDDCinema.Application.Presentation.Promotions
{
    public class ApprovalsView
    {
        List<ApprovalStatusDTO> Approvals { get; set; }
        List<ApprovalRequestsDTO> Requests { get; set; }
    }
}