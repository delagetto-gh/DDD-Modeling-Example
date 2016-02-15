﻿using Quartz.Spi;
using Quartz;
using System;
using DDDCinema.DataAccess.Movies;
using DDDCinema.DataAccess;
using DDDCinema.DataAccess.Notifications;

namespace DDDCinema.Background.Jobs
{
    public class PureJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            if (bundle.JobDetail.JobType == typeof(EmailSendingJob))
            {
                var context = new CinemaContext();
                var notificationRepository = new EfNotificationRepository(context);
                var job = new EmailSendingJob(notificationRepository, new SmtpMailSender());
                return new TransactionalJob(job, context);
            }

            if (bundle.JobDetail.JobType == typeof(SmsSendingJob))
            {
                var context = new CinemaContext();
                var notificationRepository = new EfNotificationRepository(context);
                var job = new SmsSendingJob(notificationRepository, new GateSmsSender());
                return new TransactionalJob(job, context);
            }

            throw new InvalidOperationException("Not supported job type");
        }

        public void ReturnJob(IJob job)
        {
            // dispose context & gateSmsSender
        }
    }
}
