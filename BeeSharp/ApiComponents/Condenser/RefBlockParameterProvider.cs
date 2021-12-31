using System;
using System.Net.Http;
using System.Threading.Tasks;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_block_header;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_dynamic_global_properties;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.Condenser
{
    public class RefBlockParameterProvider : IRefBlockParameterProvider
    {
        private readonly ICondenserCall _condenser;

        public RefBlockParameterProvider(ICondenserCall condenser)
        {
            _condenser = condenser;
        }

        /// <summary>
        ///     Get current refBlockNum and refBlockPrefix.
        /// </summary>
        /// <returns>refBlockNum and refBlockPrefix tuple.</returns>
        /// <exception cref="HttpRequestException">
        ///     Thrown when a request error occurs (no connection or invalid node).
        /// </exception>
        public async Task<(ushort, uint)> GetRefBlockParams()
        {
            var dynBcParams = await _condenser.GetRawCondenserApiCallAsync(
                new CondenserApiGetDynamicGlobalProperties());

            if (dynBcParams.Error.Code != 0)
                throw new HttpRequestException(
                    "Invalid request: cannot get dynamic global properties: "
                    + $"code {dynBcParams.Error.Code} message: {dynBcParams.Error.Message}");

            ushort refBlockNum;
            string headBlockId;
            if (dynBcParams.Result!.LastIrreversibleBlockNum == dynBcParams.Result!.HeadBlockNumber)
            {
                refBlockNum = (ushort) (dynBcParams.Result!.HeadBlockNumber.NumericValue & 65535);
                headBlockId = dynBcParams.Result!.HeadBlockId;
            }
            else
            {
                refBlockNum = (ushort) (dynBcParams.Result!.LastIrreversibleBlockNum.NumericValue & 65535);

                // Get blockHeader of last irreversible block + 1 (to extract headBlockId of last irreversible block)
                var block =
                    await _condenser.GetRawCondenserApiCallAsync(
                        new CondenserApiGetBlockHeader(dynBcParams.Result!.LastIrreversibleBlockNum.NumericValue + 1));

                if (block.Error.Code != 0)
                    throw new HttpRequestException(
                        "Invalid request: cannot get block with number: "
                        + $"code {dynBcParams.Result!.LastIrreversibleBlockNum.NumericValue + 1} "
                        + $"message: {block.Error.Message}");

                headBlockId = block.Result!.Previous;
            }

            // Extract refBlockPrefix from headBlockId
            // Skip the first 8hexChars/4bytes of headBlockId and take only the next 8hexChars/4bytes
            var rawHexRefBlockPrefix = headBlockId[8..16]!;
            var rawRefBlockPrefixBytes = ByteHelper.StringToByteArray(rawHexRefBlockPrefix!);

            var refBlockPrefix = BitConverter.ToUInt32(rawRefBlockPrefixBytes);
            return (refBlockNum, refBlockPrefix);
        }
    }
}