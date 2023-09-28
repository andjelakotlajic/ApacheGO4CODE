using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;

        public LabelService(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task DeleteLabel(int labelId)
        {
            var label = await _labelRepository.GetLabelsByPostIdAsync(labelId);
            await _labelRepository.DeleteLabel(label);
        }

        public async Task<IEnumerable<PostLabel>> GetLabelsByPostId(int postId)
        {
            var results = await _labelRepository.GetLabelsByPostId(postId);
            return results;
        }
    }
}
