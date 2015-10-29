using System;

/// <summary>
/// offer a thread safe method for raising an event
/// <example>
/// protected virtual viud OnNewMail(NewMailEventArgs e){
///     e.Raise(this, ref m_NewMail);}
/// </example>
/// </summary>
public static class EventArgExtensions
{
    public static void Raise<TEventArgs>(this TEventArgs e,
        Object sender, ref EventHandler<TEventArgs> eventDelegate)
    {
        // Copy a reference to the delegate field now into a temporary field for thread safety
        EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);

        // If any methods registered interest with our event, notify them
        if (temp != null) temp(sender, e);
    }
}