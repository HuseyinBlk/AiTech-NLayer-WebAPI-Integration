using AiTech.DTO.Common;

namespace AiTech.DTO.FeatureDtos;

public record UpdateFeatureDto(int Id, string Title, string Icon, string Description) : IBaseDto;
