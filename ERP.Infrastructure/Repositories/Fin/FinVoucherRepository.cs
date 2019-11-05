using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;
using ERP.Core.Models.Finance.GeneralVM;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class FinVoucherRepository : IFinVoucherRepository
    {

        private readonly ErpDbContext _db;
        public FinVoucherRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(FinVoucher finVoucher, List<FinVoucherDetail> lst)
        {
            using (var context = _db.Database.BeginTransaction())
            {
                try
                {
                    finVoucher = GetVoucherKey(finVoucher);
                    _db.FinVoucher.Add(finVoucher);
                    FinLedger finLedger = new FinLedger();
                    finVoucher.FinVoucherDetail = lst;
                    foreach (var vDetail in finVoucher.FinVoucherDetail)
                    {
                        vDetail.VKey = finVoucher.VKey;
                        _db.FinVoucherDetail.Add(vDetail);
                        if (finVoucher.IsPosted)

														   
                        {
                            var _led = AutoMapper.Mapper.Map<ERP.Core.Models.Finance.FinVoucherDetail, ERP.Core.Models.Finance.FinLedger>(vDetail);
                            _led.CreateDate = DateTime.Now;
												  
												   
						  

                            _db.FinLedger.Add(_led);
                        }

                    }
                    _db.SaveChanges();
                    context.Commit();
                }
                catch (Exception e)
                {
                    context.Rollback();
                    Console.WriteLine(e);
                    throw;
                }
				
            }
			
		 

        }
        public void Edit(FinVoucher existingVoucher, string vKey, List<FinVoucherDetail> lst)
        {
            using (var context = _db.Database.BeginTransaction())
            {
                try
                {
																												
                    _db.Entry(existingVoucher).State = EntityState.Modified;
                    var cmdDetail = ("DELETE FROM FinVoucherDetails WHERE VKey = " + vKey);
                    _db.Database.ExecuteSqlCommand(cmdDetail);
                    var cmd = ("DELETE FROM FinLedgers WHERE VKey = " + vKey);
                    _db.Database.ExecuteSqlCommand(cmd);
										

                    if (existingVoucher != null)
                    {
                        existingVoucher.FinVoucherDetail.Clear();
                        existingVoucher.FinVoucherDetail = lst;
						
                        foreach (var vDetail in existingVoucher.FinVoucherDetail)
                        {

                            vDetail.VKey = existingVoucher.VKey;
                            _db.FinVoucherDetail.Add(vDetail);
                            if (existingVoucher.IsPosted)
															   
                            {
                                var led = AutoMapper.Mapper
                                    .Map<ERP.Core.Models.Finance.FinVoucherDetail, ERP.Core.Models.Finance.FinLedger>(
													 
                                        vDetail);
                                led.CreateDate = DateTime.Now;
                                _db.FinLedger.Add(led);
                            }
							  

														 
											  
                        }
                    }
                    _db.SaveChanges();
                    context.Commit();
                }
                catch (Exception e)
                {
                    context.Rollback();
                    Console.WriteLine(e);
                    throw;
                }

            }
        }
        public void PostorUnpost(FinVoucher existingVoucher)
        {
            using (var context = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(existingVoucher).State = EntityState.Modified;
                    if (existingVoucher.IsPosted)
                    {
                        foreach (var vDetail in existingVoucher.FinVoucherDetail)
                        {
                            vDetail.VKey = existingVoucher.VKey;
                            var finLedger = AutoMapper.Mapper.Map<ERP.Core.Models.Finance.FinVoucherDetail, ERP.Core.Models.Finance.FinLedger>(vDetail);
                            finLedger.CreateDate = DateTime.Now;
                            _db.FinLedger.Add(finLedger);
                        }
                    }
                    else
                    {
                        var cmd = ("DELETE FROM FinLedgers WHERE VKey = " + existingVoucher.VKey);
                        _db.Database.ExecuteSqlCommand(cmd);
                    }
                    _db.SaveChanges();
                    context.Commit();

                }
                catch (Exception e)
                {
                    context.Rollback();
                    Console.WriteLine(e);
                    throw;
                }
            }

        }
        public void Remove(string vKey)
        {
            throw new NotImplementedException();
        }

        public string GetVoucherKey(FinVoucher voucher, string key)
        {
            throw new NotImplementedException();
        }

        public FinVoucher GetVoucherKey(FinVoucher finVoucher)
        {
            int maxno = _db.FinVoucher.Where(a => a.Vtype == finVoucher.Vtype).Select(a => a.VoucherNo).DefaultIfEmpty(0).Max();
            maxno = maxno + 1;
            finVoucher.VoucherNo = maxno;
            //voucher Key   companyCode+Month+Year+VoucherType+ NewCode
            string VoucherKey = "01" + finVoucher.CreateDate.ToString("MM").PadLeft(2, '0') + finVoucher.CreateDate.ToString("yyyy").PadLeft(4, '0') + finVoucher.Vtype + maxno.ToString().PadLeft(9, '0');
            finVoucher.VKey = VoucherKey;
            return finVoucher;
        }
        public FinVoucher GetFinVoucherByKey(string vKey)
        {
            FinVoucher voucher = _db.FinVoucher.Find(vKey);
            var detail = _db.FinVoucherDetail.Where(x => x.VKey == vKey);
            return voucher;
        }

																				 
		 
																			   
		 

        public IEnumerable<FinVoucher> GetAllFinVouchers()
        {
            return _db.FinVoucher.ToList();
        }
        public IEnumerable<FinVoucher> GetAllFinVouchers(string voucherType)
        {
            return _db.FinVoucher.Where(a => a.Vtype == voucherType).ToList();
        }
        public IEnumerable<FinLedger> GetAllFinLedger()
        {
            return _db.FinLedger.ToList();
        }

        public List<VM_Vouchers> getVoucherWithAccount(DateTime sd, DateTime ed, string glCode)
        {
            try
            {
                List<VM_Vouchers> _vouchers = new List<VM_Vouchers>();

                var vouchers = (from vm in _db.FinVoucher
                                join vd in _db.FinVoucherDetail
                                   on vm.VKey equals vd.VKey
                                join ca in _db.CoaL5
                                   on vd.GlCode equals ca.L5Code
                                where (vm.VoucherDate >= sd && vm.VoucherDate <= ed && vd.GlCode == glCode)
                                select new
                                {
                                    VKey = vm.VKey,
                                    VoucherNo = vm.VoucherNo,
                                    VoucherDate = vm.VoucherDate,
                                    FescalMonth = vm.FescalMonth,
                                    Vtype = vm.Vtype,
                                    TotalDebit = vm.TotalDebit,
                                    TotalCredit = vm.TotalCredit,
                                    CheqNo = vm.CheqNo,
                                    CreateDate = vm.CreateDate,
                                    PostedDate = vm.PostedDate,
                                    VoucherDetail = vm.Detail,
                                    ModifiedOn = vm.ModifiedOn,
                                    isPosted = vm.IsPosted,
                                    isEdited = vm.IsEdited,
                                    isVerified = vm.IsVerified,
                                    GlAccount = vd.GlCode,
                                    Detail = vd.Detail,
                                    Debit = vd.Debit,
                                    Credit = vd.Credit
                                }).ToList();

                foreach (var voc in vouchers)
                {
                    VM_Vouchers vm = new VM_Vouchers();
                    vm.VKey = voc.VKey;
                    vm.VoucherNo = voc.VoucherNo;
                    vm.VoucherDate = voc.VoucherDate;
                    vm.FescalMonth = voc.FescalMonth;
                    vm.Vtype = voc.Vtype;
                    vm.TotalDebit = voc.TotalDebit;
                    vm.TotalCredit = voc.TotalCredit;
                    vm.CheqNo = voc.CheqNo;
                    vm.CreateDate = voc.CreateDate;
                    vm.PostedDate = voc.PostedDate;
                    vm.VoucherDetail = voc.VoucherDetail;
                    vm.ModifiedOn = voc.ModifiedOn;
                    vm.isPosted = voc.isPosted;
                    vm.isEdited = voc.isEdited;
                    vm.isVerified = voc.isVerified;
                    vm.GlAccount = voc.GlAccount;
                    vm.Detail = voc.Detail;
                    vm.Debit = voc.Debit;
                    vm.Credit = voc.Credit;

                    _vouchers.Add(vm);

                }

                return _vouchers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           

        }


        public List<VM_Vouchers> getVoucherWithAccountAndDetail(DateTime sd, DateTime ed, string glCode, string detail)
        {
            List<VM_Vouchers> _vouchers = new List<VM_Vouchers>();

            var vouchers = (from vm in _db.FinVoucher
                            join vd in _db.FinVoucherDetail
                               on vm.VKey equals vd.VKey
                            join ca in _db.CoaL5
                                on vd.GlCode equals ca.L5Code
                            where (vm.VoucherDate >= sd && vm.VoucherDate <= ed && vd.GlCode == glCode && vd.Detail.Contains(detail))
                            select new
                            {
                                VKey = vm.VKey,
                                VoucherNo = vm.VoucherNo,
                                VoucherDate = vm.VoucherDate,
                                FescalMonth = vm.FescalMonth,
                                Vtype = vm.Vtype,
                                TotalDebit = vm.TotalDebit,
                                TotalCredit = vm.TotalCredit,
                                CheqNo = vm.CheqNo,
                                CreateDate = vm.CreateDate,
                                PostedDate = vm.PostedDate,
                                VoucherDetail = vm.Detail,
                                ModifiedOn = vm.ModifiedOn,
                                isPosted = vm.IsPosted,
                                isEdited = vm.IsEdited,
                                isVerified = vm.IsVerified,
                                GlAccount = vd.GlCode,
                                Detail = vd.Detail,
                                Debit = vd.Debit,
                                Credit = vd.Credit
                            }).ToList();

            foreach (var voc in vouchers)
            {
                VM_Vouchers vm = new VM_Vouchers();
                vm.VKey = voc.VKey;
                vm.VoucherNo = voc.VoucherNo;
                vm.VoucherDate = voc.VoucherDate;
                vm.FescalMonth = voc.FescalMonth;
                vm.Vtype = voc.Vtype;
                vm.TotalDebit = voc.TotalDebit;
                vm.TotalCredit = voc.TotalCredit;
                vm.CheqNo = voc.CheqNo;
                vm.CreateDate = voc.CreateDate;
                vm.PostedDate = voc.PostedDate;
                vm.VoucherDetail = voc.VoucherDetail;
                vm.ModifiedOn = voc.ModifiedOn;
                vm.isPosted = voc.isPosted;
                vm.isEdited = voc.isEdited;
                vm.isVerified = voc.isVerified;
                vm.GlAccount = voc.GlAccount;
                vm.Detail = voc.Detail;
                vm.Debit = voc.Debit;
                vm.Credit = voc.Credit;

                _vouchers.Add(vm);

            }

            return _vouchers;

        }

    }
}
