namespace GameOfLife.Helpers
{
    public static class FieldHelper
    {
        /// <summary>
        /// Calculates the X-axis value from given index and the axis limit.
        /// </summary>
        /// <param name="index">Index of a list</param>
        /// <param name="fieldWidth">Limit of the X-axis</param>
        /// <returns>The correct X-coordinate from an index of a list</returns>
        public static int GetXCoordinateFromIndex(int index, int fieldWidth) => (index % fieldWidth);

        /// <summary>
        /// Calculates the Y-axis value from given index and the axis limit.
        /// </summary>
        /// <param name="index">Index of a list</param>
        /// <param name="fieldWidth">Limit of the Y-axis</param>
        /// <returns>The correct Y-coordinate from an index of a list</returns>
        public static int GetYCoordinateFromIndex(int index, int fieldWidth) => ((index - (index % fieldWidth)) / fieldWidth);

        /// <summary>
        /// Converts given coordinates into an index for a list.
        /// </summary>
        /// <param name="x">Value of the X-axis</param>
        /// <param name="y">Value of the Y-axis</param>
        /// <param name="fieldWidth">Limit of the X-axis</param>
        /// <returns>Index for a list based on X and Y coordinates</returns>
        public static int GetIndexValueFromCoordinates(int x, int y, int fieldWidth) => ((y * fieldWidth) + x);

        /// <summary>
        /// Checks whether a given X or Y coordinate lies in the valid space of given axis limit.
        /// This functions behavior is unknown in the case of given X-axis coordinate and given limit of the Y-axis and vice versa.
        /// </summary>
        /// <param name="coordinate">X or Y coordinate</param>
        /// <param name="axisLimit">Limit of the related axis of the coordinate</param>
        /// <returns>Returns true if the given coordinate lies within its axis space otherwise false</returns>
        public static bool IsCoordinateValid(int coordinate, int axisLimit) => coordinate >= 0 && coordinate < axisLimit;
    }
}
