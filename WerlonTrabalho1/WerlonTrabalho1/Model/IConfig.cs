using SQLite.Net.Interop;

namespace WerlonTrabalho1.Model
{
    public interface IConfig
    {
        string DiretorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
