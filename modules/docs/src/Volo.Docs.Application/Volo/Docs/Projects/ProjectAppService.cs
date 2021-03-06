using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Docs.Projects
{
    public class ProjectAppService : ApplicationService, IProjectAppService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectAppService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ListResultDto<ProjectDto>> GetListAsync()
        {
            var projects = await _projectRepository.GetListAsync();

            return new ListResultDto<ProjectDto>(
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects)
            );
        }
    }
}