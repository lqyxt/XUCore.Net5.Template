using System.Threading;
using System.Threading.Tasks;
using XUCore.Ddd.Domain.Events;
using XUCore.Net5.Template.Domain.Core.Entities.Sys.Admin;

namespace XUCore.Net5.Template.Domain.Sys.AdminUser
{
    public class CreateEvent : Event
    {
        public long Id { get; set; }
        public AdminUserEntity AdminUser { get; set; }
        public CreateEvent(long id, AdminUserEntity user)
        {
            Id = id;
            AdminUser = user;
            AggregateId = id.ToString();
        }
        /// <summary>
        /// 事件通知操作
        /// </summary>
        public class Handler : NotificationEventHandler<CreateEvent>
        {
            public Handler()
            {
            }
            /// <summary>
            /// 接受消息处理创建后的业务
            /// </summary>
            /// <param name="notification"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public override async Task Handle(CreateEvent notification, CancellationToken cancellationToken)
            {

                await Task.CompletedTask;
            }
        }
    }
}
