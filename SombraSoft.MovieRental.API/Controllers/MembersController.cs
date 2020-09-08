using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SombraSoft.MovieRental.API.Services.Member;
using SombraSoft.MovieRental.MongoDB.Collections;
using SombraSoft.MovieRental.MongoDB.DTO;

namespace SombraSoft.MovieRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IEnumerable<Member>> Get(CancellationToken token)
        {
            return await _memberService.GetAsync(token);
        }

        [HttpGet("{id}")]
        public async Task<Member> Get(string id)
        {
            return await _memberService.GetAsync(id);
        }

        [HttpPost]
        public async Task<Member> Create(Member member)
        {
            return await _memberService.CreateAsync(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Member member)
        {
            await _memberService.UpdateAsync(id, member);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _memberService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("Summaries")]
        public async Task<IEnumerable<MemberSummary>> GetMembersSummary()
        {
            return await _memberService.GetMemberSummariesAsync();
        }
    }
}
