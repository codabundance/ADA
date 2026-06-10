def leaders_brute_force(self, nums):
        return_list = []
        n = len(nums)
        for i in range(0,n-1):
            is_leader = False
            for j in range(i+1,n):
                if nums[i] > nums[j]:
                    is_leader = True
                    continue
                else:
                    is_leader= False
                    break
            if is_leader:
                return_list.append(nums[i])
        return_list.append(nums[n-1])
        return return_list

def leaders_optimal(self, nums):
        n = len(nums)
        return_list = []
        Max = nums[n-1]
        return_list.append(Max)
        for i in range(n-1, -1, -1):
            if nums[i] > Max:
                Max = nums[i]
                return_list.append(Max)
        return_list.reverse()
        return return_list
        