/// <summary>
/// A gaussian or normal distribution.
/// </summary>
public class NormalDistribution {
    private double m_factor;
    public NormalDistribution(double mean, double sigma) {
        Mean = mean;
        Sigma = sigma;
        Variance = sigma * sigma;
    }

    public double Mean { get; private set; }

    public double Variance { get; private set; }

    public double Sigma { get; private set; }

    private bool m_useLast;

    private double m_y2;

    /// <summary>
    /// Sample a value from distribution for a given random varible.
    /// </summary>
    /// <param name="rnd">Generator for a random varible between 0-1 (inculsive)</param>
    /// <returns>A value from the distribution</returns>
    public double Sample(System.Random rnd) {
        double x1, x2, w, y1;
        
        if (m_useLast) {
            y1 = m_y2;
            m_useLast = false;
        } else {
            do {
                x1 = 2.0 * rnd.NextDouble() - 1.0;
                x2 = 2.0 * rnd.NextDouble() - 1.0;
                w = x1 * x1 + x2 * x2;
            } while (w >= 1.0);
            
            w = Math.Sqrt(-2.0 * Math.Log(w) / w);
            y1 = x1 * w;
            m_y2 = x2 * w;
            m_useLast = true;
        }
        
        return Mean + y1 * Sigma;
    }
}
