using AiTech.DTO.Common;

namespace AiTech.DTO.FeatureDtos;

public record ResultFeatureDto(int Id, string Title, string Icon, string Description, DateTime CreatedDate) : IBaseDto;
