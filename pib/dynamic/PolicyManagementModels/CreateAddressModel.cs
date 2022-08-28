using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PolicyManagementModels
{
   public class CreateAddressModel
    {
    [Required(ErrorMessage = "Address is a required")]
	public string AddressLine1 { get; set; }
	public string AddressLine2 { get; set; }
	public string PostalCode  { get; set; }
	public string City  { get; set; }
	public string Province  { get; set; }
    public string AddressType  { get; set; }
	// For when address belongs to a branch (branch name)
	public string Name { get; set; }
	public int AgentID { get; set; }
	public int MemDetNum { get; set; }
	}
}
