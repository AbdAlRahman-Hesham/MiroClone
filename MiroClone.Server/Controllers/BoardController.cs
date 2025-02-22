using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiroClone.Server.BLL.RepositoryInterfaces;
using MiroClone.Server.BLL.UnitOfWork;
using MiroClone.Server.DAL.Model;

[ApiController]
[Route("api/[controller]")]
[Authorize()]
public class BoardController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IBoardRepository _boardRepository = unitOfWork.BoardRepository;



    #region Get
    // GET: api/Board
    [HttpGet]
    public async Task<IActionResult> GetBoards()
    {
        try
        {
            var boards = await _boardRepository.GetAllAsync();
            return Ok(boards);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Board/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBoard(int id)
    {
        try
        {
            var board = await _boardRepository.GetByIdAsync(id);

            if (board == null)
            {
                return NotFound($"Board with ID {id} not found");
            }

            return Ok(board);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Board/search?title=example
    [HttpGet("search")]
    public async Task<IActionResult> SearchBoards([FromQuery] string title)
    {
        try
        {
            var boards = await _boardRepository.FindAsync(b => b.Title.Contains(title));
            return Ok(boards);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    #endregion

    #region Post
    // POST: api/Board
    [HttpPost]
    public async Task<IActionResult> CreateBoard([FromBody] Board board)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _boardRepository.AddAsync(board);
            await _boardRepository.SaveAsync();

            return CreatedAtAction(nameof(GetBoard), new { id = board.Id }, board);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    #endregion

    #region Put
    // PUT: api/Board/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBoard(int id, [FromBody] Board board)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != board.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingBoard = await _boardRepository.GetByIdAsync(id);
            if (existingBoard == null)
            {
                return NotFound($"Board with ID {id} not found");
            }

            await _boardRepository.UpdateAsync(board);
            await _boardRepository.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    #endregion

    #region Delete
    // DELETE: api/Board/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBoard(int id)
    {
        try
        {
            var board = await _boardRepository.GetByIdAsync(id);
            if (board == null)
            {
                return NotFound($"Board with ID {id} not found");
            }

            await _boardRepository.DeleteAsync(board);
            await _boardRepository.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    } 
    #endregion


}