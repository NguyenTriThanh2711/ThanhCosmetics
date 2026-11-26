using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.Models.SkinTestModel;
using ThanhCometics.Repository.ViewModels;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class SkinTestService : ISkinTestService
    {
        private readonly ISkinTestRepository _skinTestRepository;
        private readonly ICustomerService _customerService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public SkinTestService(IMapper mapper, ISkinTestRepository skinTestRepository, ICustomerService customerService, ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _skinTestRepository = skinTestRepository;
            _customerService = customerService;
        }
        public async Task<MethodResult<SkinTestViewModel>> GetActiveSkinTestAsync()
        {
            var skinTest  = await _skinTestRepository.GetActiveSkinTestAsync();
            var result = _mapper.Map<SkinTestViewModel>(skinTest);
            if (result == null) return new MethodResult<SkinTestViewModel>.Failure("Cannot get skin test!!", StatusCodes.Status500InternalServerError);
            return new MethodResult<SkinTestViewModel>.Success(result);
        }

        public async Task<MethodResult<SkinTestResultViewModel>> DetermineSkinTypeAsync(int userId, ListUserAnswerModel list)
        {
            
            if (list.ListUserAnswer == null || list.ListUserAnswer.Count == 0)
                return new MethodResult<SkinTestResultViewModel>.Failure("You have to answer at least one question!!", StatusCodes.Status400BadRequest);

            var skinTypesFromAnswers = await _skinTestRepository.GetSkinTypeAnswersAsync(list);
            if (skinTypesFromAnswers == null) 
                return new MethodResult<SkinTestResultViewModel>.Failure("There is not any skin type from your result", StatusCodes.Status500InternalServerError);

            var mostSkinType = skinTypesFromAnswers
                .Where(answer => answer.SkinTypeAnswerSkinTypes != null)
                .SelectMany(skinTypesFromAnswers => skinTypesFromAnswers.SkinTypeAnswerSkinTypes)
                .Where(link => link.SkinType != null)
                .GroupBy(answer => answer.SkinTypeId)
                .Select(group => new
                {
                    SkinType = group.First().SkinType,
                    Score = group.Count()
                })
                .OrderByDescending(item => item.Score)
                .ThenBy(item => item.SkinType.Priority)
                .FirstOrDefault();
            var customer = await _customerRepository.GetCustomerByIdAsync(userId);
            if (customer != null) customer.SkinTypeId = mostSkinType?.SkinType.SkinTypeId;
            var result = _mapper.Map<SkinTestResultViewModel>(mostSkinType);
            if (result == null) return new MethodResult<SkinTestResultViewModel>.Failure("There is some thing wrong in identify the right skin type", StatusCodes.Status500InternalServerError);
            return new MethodResult<SkinTestResultViewModel>.Success(result);
        }
    }
}
