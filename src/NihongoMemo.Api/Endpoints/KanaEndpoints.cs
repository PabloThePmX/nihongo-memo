using Microsoft.AspNetCore.Mvc;

namespace NihongoMemo.Api.Endpoints
{
    public static class KanaEndpoints
    {
        #region Hiragana
        private static readonly string[] _hiraganaGyoA = ["あ", "い", "う", "え", "お"];
        private static readonly string[] _hiraganaGyoKa = ["か", "き", "く", "け", "こ"];
        private static readonly string[] _hiraganaGyoSa = ["さ", "し", "す", "せ", "そ"];
        private static readonly string[] _hiraganaGyoTa = ["た", "ち", "つ", "て", "と"];
        private static readonly string[] _hiraganaGyoNa = ["な", "に", "ぬ", "ね", "の"];
        private static readonly string[] _hiraganaGyoHa = ["は", "ひ", "ふ", "へ", "ほ"];
        private static readonly string[] _hiraganaGyoMa = ["ま", "み", "む", "め", "も"];
        private static readonly string[] _hiraganaGyoYa = ["や", "ゆ", "よ"];
        private static readonly string[] _hiraganaGyoRa = ["ら", "り", "る", "れ", "ろ"];
        private static readonly string[] _hiraganaGyoWa = ["わ", "を", "ん"];

        private static readonly string[] _hiragana =
        [
            .._hiraganaGyoA, .._hiraganaGyoKa, .._hiraganaGyoSa, .._hiraganaGyoTa,
            .._hiraganaGyoNa, .._hiraganaGyoHa, .._hiraganaGyoMa, .._hiraganaGyoYa,
            .._hiraganaGyoRa, .._hiraganaGyoWa
        ];
        #endregion

        #region Katakana
        private static readonly string[] _katakanaGyoA = ["ア", "イ", "ウ", "エ", "オ"];
        private static readonly string[] _katakanaGyoKa = ["カ", "キ", "ク", "ケ", "コ"];
        private static readonly string[] _katakanaGyoSa = ["サ", "シ", "ス", "セ", "ソ"];
        private static readonly string[] _katakanaGyoTa = ["タ", "チ", "ツ", "テ", "ト"];
        private static readonly string[] _katakanaGyoNa = ["ナ", "ニ", "ヌ", "ネ", "ノ"];
        private static readonly string[] _katakanaGyoHa = ["ハ", "ヒ", "フ", "ヘ", "ホ"];
        private static readonly string[] _katakanaGyoMa = ["マ", "ミ", "ム", "メ", "モ"];
        private static readonly string[] _katakanaGyoYa = ["ヤ", "ユ", "ヨ"];
        private static readonly string[] _katakanaGyoRa = ["ラ", "リ", "ル", "レ", "ロ"];
        private static readonly string[] _katakanaGyoWa = ["ワ", "ヲ", "ン"];
        private static readonly string[] _katakana =
        [
            .._katakanaGyoA, .._katakanaGyoKa, .._katakanaGyoSa, .._katakanaGyoTa,
            .._katakanaGyoNa, .._katakanaGyoHa, .._katakanaGyoMa, .._katakanaGyoYa,
            .._katakanaGyoRa, .._katakanaGyoWa
        ];
        #endregion

        private static string[] _allKana = [.._hiragana, .._katakana];

        private static Dictionary<string, string[]> _options = new Dictionary<string, string[]>
        {
            { "ha", _hiraganaGyoA },
            { "hka", _hiraganaGyoKa },
            { "hsa", _hiraganaGyoSa },
            { "hta", _hiraganaGyoTa },
            { "hna", _hiraganaGyoNa },
            { "hha", _hiraganaGyoHa },
            { "hma", _hiraganaGyoMa },
            { "hya", _hiraganaGyoYa },
            { "hra", _hiraganaGyoRa },
            { "hwa", _hiraganaGyoWa },
            { "h", _hiragana },
            { "ka", _katakanaGyoA  },
            { "kka", _katakanaGyoKa },
            { "ksa", _katakanaGyoSa },
            { "kta", _katakanaGyoTa },
            { "kna", _katakanaGyoNa },
            { "kha", _katakanaGyoHa },
            { "kma", _katakanaGyoMa },
            { "kya", _katakanaGyoYa },
            { "kra", _katakanaGyoRa },
            { "kwa", _katakanaGyoWa },
            { "k", _katakana },
        };

        public static WebApplication MapKanaEndpoints(this WebApplication app)
        {
            app.MapGet("/kana", ([FromQuery] string[] gyo) =>
            {
                if (gyo == null || gyo.Length == 0)
                    return Results.Ok(_allKana);

                var filteredGyo = new List<string>();
                foreach (var key in gyo)
                    if (_options.TryGetValue(key, out var gyoCollection))
                        filteredGyo.AddRange(gyoCollection);

                return Results.Ok(filteredGyo);
            });

            return app;
        }
    }
}
