namespace Pdc.System.Sample
{
    /// <summary>
    /// Example from Sextion 3 of https://pdfs.semanticscholar.org/b0ae/820f7f077eda74c11fc22d0da45f2300a4a0.pdf
    /// </summary>
    public interface ICruiseControlConnector
    {
        void EngineOn();
        void EngineOff();
        void Accelerate();
        void Break();
        void Resume();
    }
}