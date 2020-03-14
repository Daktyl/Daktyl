using System;
using System.Threading.Tasks;

namespace Daktyl.Core.WebSockets
{
	public interface IWebSocket : IAsyncDisposable
	{
		Task Start(string endpoint);
		Task Stop();
		Task Send(ArraySegment<byte> data);
		Task<ArraySegment<byte>> Receive();
	}
}