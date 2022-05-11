﻿namespace My.Events.Messages
{
    public class AtChain : BaseChain
    {
        public uint AtUin { get; }

        /// <summary>
        /// Display string
        /// </summary>
        internal string DisplayString { get; set; }

        private AtChain(uint uin)
            : base(ChainType.At, ChainMode.Multiple)
        {
            AtUin = uin;
        }

        /// <summary>
        /// Create an at chain
        /// </summary>
        /// <param name="memberUin"></param>
        /// <returns></returns>
        public static AtChain Create(uint memberUin)
            => new(memberUin);

        /// <summary>
        /// Parse the code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        internal static AtChain Parse(string code)
        {
            var args = GetArgs(code);
            {
                var atUin = args["qq"];
                return Create(atUin == "all" ? 0 : uint.Parse(atUin));
            }
        }

        public override string ToString()
            => $"[KQ:at,qq={(AtUin == 0 ? "all" : AtUin.ToString())}]";

        internal override string ToPreviewString()
            => DisplayString ?? $"@{AtUin}";
    }

}