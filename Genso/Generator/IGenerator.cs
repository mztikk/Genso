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

        /// <summary>
        /// Fully writes the data, calling <see cref="Begin"/> and <see cref="End"/>
        /// </summary>
        /// <returns>Should return <see langword="true"/> if it wrote anything</returns>
        bool Make()
        {
            bool begin = Begin();
            bool end = End();

            return begin || end;
        }
    }
}
