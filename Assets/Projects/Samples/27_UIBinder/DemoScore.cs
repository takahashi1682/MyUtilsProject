using MyUtils.Parameter;

namespace Projects._27_UIBinder
{
    public interface IDemoScore : IFloatParameter
    {
    }

    /// <summary>
    /// FloatBinder / StringBinder / FloatAnimatedBinder のデモ用に用意した、
    /// AbstractFloatParameterの最小実装（スコア表示用の値）。
    /// </summary>
    public class DemoScore : AbstractFloatParameter, IDemoScore
    {
    }
}
