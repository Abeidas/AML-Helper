using System.Threading;
using AMLHelper.View;

namespace AMLHelper.Controller
{
    public class ResponseTrigger
    {
        private static Thread _thread;

        private static volatile bool _isBusy;
        private static volatile bool _counterReset; //um zu verhindern, dass mehrere verschiedene Arbeitsphasen zur selben Wartezeit beitragen

        private static readonly object SyncLock = new object(); //um sicherzustellen, dass nicht entschieden wird, einen Thread weiterlaufen zu lassen, während dieser sich gerade beendet

        private static int _busyCounter; //damit rekursive Aufrufe keinen Effekt haben, da nur der oberste für die Wartezeit entscheidend ist

        /// <summary>
        /// Startet einen nebenläufigen Timer, der nach 500-800ms ein Popup öffnet, das dem Nutzer sagt, dass gerade brav gearbeitet wird.
        /// Einfach vor rechenintensiven Abschnitten aufrufen, die Ausführung wird nicht blockiert.
        /// </summary>
        public static void MarkBusy()
        {
            _busyCounter++;
            if (_isBusy)
            {
                return;
            }
            lock (SyncLock)
            {
                _isBusy = true;
                if (_counterReset)
                {
                    //es läuft noch ein Thread, der sich resetten wird. D.h. es ist kein neuer nötig
                    return;
                }
            }
            _thread = new Thread(PopupWindow);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.IsBackground = true;
            _thread.Start();
        }

        /// <summary>
        /// Stoppt den Timer für rechenintensive Abschnitte und schließt ggf. das Wartezeit-Popup.
        /// </summary>
        public static void JobFinished()
        {
            _busyCounter--;
            if (!_isBusy || _busyCounter > 0)
                return;
            _isBusy = false;
            _counterReset = true;
        }

        private static void PopupWindow()
        {
            //Stopwatch control = new Stopwatch();
            //control.Start();

            for (var i = 0; i < 16; i++) {
                Thread.Sleep(32); // 16*32 = 512 ms = etwa eine halbe Sekunde Wartezeit, bis eine Meldung erscheint
                if (!_isBusy)
                {
                    return;
                }
                if (_counterReset)
                {
                    i = 0;
                    _counterReset = false;
                }
            }
            //control.Stop();

            //System.Diagnostics.Debug.WriteLine("Countdown done, opening new window. Countdown time elapsed: " + control.ElapsedMilliseconds); //im Durchschnitt vergehen etwa 750 ms bis zum Aufploppen des Wartefensters

            BusyBox box = new BusyBox();
            while (true)
            {
                Thread.Sleep(32);
                if (!_isBusy)
                {
                    lock (SyncLock)
                    {
                        box.Close();
                        _counterReset = false;
                    }
                    return;
                }
            }
        }
    }
}
