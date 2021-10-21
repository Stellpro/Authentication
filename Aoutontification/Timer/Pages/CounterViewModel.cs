using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timer.Data.Model;

namespace Timer.Pages
{

    public class CounterViewModel : ComponentBase
    {
        public Time Clock = new Time();
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public async Task Timer(Time Clock)
        {
            try
            {
                while (true)
                {
                    cancelTokenSource.Token.ThrowIfCancellationRequested();
                    if (Clock.Secund == 60)
                    {
                        Clock.Minit = Clock.Minit + 1;
                        Clock.Secund = 0;
                    }
                    else
                    {
                        await Task.Delay(1000);
                        Clock.Secund = Clock.Secund + 1;
                    }
                    Console.WriteLine($"Minut:{Clock.Minit} Secund:{Clock.Secund}");
                    StateHasChanged();
                }

            }
            catch (Exception)
            {
                cancelTokenSource=new CancellationTokenSource();
                throw;
            }

        }
        public void paused()
        {
            cancelTokenSource.Cancel();
        }
        public Time resturt()
        {
            Clock.Secund = 0;
            Clock.Minit = 0;
            return Clock;
        }

    }
}
