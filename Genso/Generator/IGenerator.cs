namespace Genso.Generator
{
    /// <summary>
    /// Represents a Generator that generates data
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Begins writing data
        /// </summary>
        /// <returns>Should return <see langword="true"/> if it wrote anything</returns>
        bool Begin();

        /// <summary>
        /// Finishes writing data
        /// </summary>
        /// <returns>Should return <see langword="true"/> if it wrote anything</returns>
        bool End();
    }
}
